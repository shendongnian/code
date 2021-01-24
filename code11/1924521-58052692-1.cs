    using System;
    using System.Threading.Tasks;
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("starting the loop");
                
                Task.Delay(1000);
                Console.WriteLine("this is printed inmediately, previous delay does not stop the execution");
                
                await Task.Delay(1000);
                Console.WriteLine("this happens 1 second later, the previous delay is awaited");
            }
        }
    }
