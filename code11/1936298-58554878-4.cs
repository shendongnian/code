    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static async Task Main()
            {
                Console.WriteLine("Main thread ID = " + Thread.CurrentThread.ManagedThreadId);
                int result = slowMethod();
                Console.WriteLine("result = " + result);
                Console.WriteLine("After calling slowMethod(), thread ID = " + Thread.CurrentThread.ManagedThreadId);
                result = await slowMethodAsync();
                Console.WriteLine("result = " + result);
                Console.WriteLine("After calling slowMethodAsync(), thread ID = " + Thread.CurrentThread.ManagedThreadId);
            }
            static async Task<int> slowMethodAsync()
            {
                await Task.Delay(5000);
                return 42;
            }
            static int slowMethod()
            {
                Thread.Sleep(5000);
                return 42;
            }
        }
    }
