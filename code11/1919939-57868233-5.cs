    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static async Task Main()
            {
                var factory = new CancellationTokenSource(1000);
                var token   = factory.Token;
                var task    = myTask();
                var result = await Task.WhenAny(
                    WhenCanceled(token),
                    task);
                if (result == task)
                    Console.WriteLine("myTask() completed");
                else
                    Console.WriteLine("cancel token was signalled");
            }
            public static Task WhenCanceled(CancellationToken cancellationToken)
            {
                var tcs = new TaskCompletionSource<bool>();
                cancellationToken.Register(s => ((TaskCompletionSource<bool>) s).SetResult(true), tcs);
                return tcs.Task;
            }
            static async Task myTask()
            {
                await Task.Delay(2000);
            }
        }
    }
