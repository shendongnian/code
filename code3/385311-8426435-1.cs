    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            AsyncTest a = new AsyncTest();
            Task task = a.MethodAsync();
            Console.WriteLine("Waiting in Main thread");
            task.Wait();
        }
    }
    
    class AsyncTest
    {
        public async Task MethodAsync()
        {
            Console.WriteLine("Starting");
            string test = await Slow();
            Console.WriteLine("stuff in the middle");
            Console.WriteLine(test);
        }
        
        private async Task<string> Slow()
        {
            await TaskEx.Delay(5000);
            return "task string";
        }
    }
