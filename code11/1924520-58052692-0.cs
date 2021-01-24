    using System;
    using System.Threading.Tasks;
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                await Task.Delay(1000);
                Console.WriteLine("loop");
            }
        }
    }```
