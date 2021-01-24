    using System;
    using System.Threading.Tasks;
    namespace Demo
    {
        public class Program
        {
            public static async Task Main()
            {
                if (await WaitFor(MyAsyncMethod(), TimeSpan.FromSeconds(1)))
                    Console.WriteLine("First await completed");
                else
                    Console.WriteLine("First await didn't complete");
                if (await WaitFor(MyAsyncMethod(), TimeSpan.FromSeconds(3)))
                    Console.WriteLine("Second await completed");
                else
                    Console.WriteLine("Second await didn't complete");
            }
            public static async Task MyAsyncMethod()
            {
                await Task.Delay(2000);
            }
            public static async Task<bool> WaitFor(Task task, TimeSpan timeout)
            {
                return await Task.WhenAny(task, Task.Delay(timeout)) == task;
            }
        }
    }
