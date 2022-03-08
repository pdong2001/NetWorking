using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace NetWorking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập URL:");
            string url = Console.ReadLine();
            HttpClient client = new HttpClient();
            int count = 0;
            int completed = 0;
            while (true)
            {
                if (count < 1000)
                {
                    count++;
                    _ = GetAsync(url, client, () => { completed++; count--; });
                }
            }
        }
        public static async Task GetAsync(string url, HttpClient client, Action action)
        {
            await client.GetAsync(url);
            action();
        }
    }
}
