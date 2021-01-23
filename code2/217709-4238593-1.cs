    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static Task CreateTaskWithTimeout(
                int xDelay, int yDelay, int taskDelay)
            {
                var cts = new CancellationTokenSource();
                var token = cts.Token;
                var task = Task.Factory.StartNew(() =>
                {
                    // Do some work, but fail if cancellation was requested
                    token.WaitHandle.WaitOne(taskDelay);
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("Task complete");
                });
                var messageTimer = new Timer(state =>
                {
                    // Display message at first timeout
                    Console.WriteLine("X milliseconds elapsed");
                }, null, xDelay, -1);
                var cancelTimer = new Timer(state =>
                {
                    // Display message and cancel task at second timeout
                    Console.WriteLine("Y milliseconds elapsed");
                    cts.Cancel();
                }
                    , null, yDelay, -1);
                task.ContinueWith(t =>
                {
                    // Dispose the timers when the task completes
                    // This will prevent the message from being displayed
                    // if the task completes before the timeout
                    messageTimer.Dispose();
                    cancelTimer.Dispose();
                });
                return task;
            }
    
            static void Main(string[] args)
            {
                var task = CreateTaskWithTimeout(1000, 2000, 2500);
                // The task has been started and will display a message after
                // one timeout and then cancel itself after the second
                // You can add continuations to the task
                // or wait for the result as needed
                try
                {
                    task.Wait();
                    Console.WriteLine("Done waiting for task");
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Error waiting for task:");
                    foreach (var e in ex.InnerExceptions)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
