    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static async Task Main()
            {
                var factory = new CancellationTokenSource(1000); // Change to 3000 for different result.
                var token   = factory.Token;
                var task    = myTask();
                var result = await Task.WhenAny(
                    Task.Run(() => token.WaitHandle.WaitOne()),
                    task);
                if (result == task)
                    Console.WriteLine("myTask() completed");
                else
                    Console.WriteLine("cancel token was signalled");
            }
            static async Task myTask()
            {
                await Task.Delay(2000);
            }
        }
    }
