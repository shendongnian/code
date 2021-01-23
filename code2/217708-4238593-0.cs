    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xDelay = 1000;
                var yDelay = 2000;
                var taskDelay = 2500;
    
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
                        Console.WriteLine("Y milliseconds elapsed; cancelling");
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
