    using System;
    using System.Linq;
    using System.Threading;
    using System.Diagnostics;
    
    namespace CSharpSandbox
    {
        class Program
        {
            static void SomeTask(int sleepInterval, CountdownEvent countDown)
            {
                try
                {
                    // pretend this did something more profound
                    Thread.Sleep(sleepInterval);
                }
                finally
                {
                    // need to signal in a finally block, otherwise an exception may occur and prevent
                    // this from being signaled
                    countDown.Signal();
                }
            }
    
            static CountdownEvent StartTasks(int count)
            {
                Random rnd = new Random();
    
                CountdownEvent countDown = new CountdownEvent(count);
    
                for (int i = 0; i < count; i++)
                {
                    ThreadPool.QueueUserWorkItem(_ => SomeTask(rnd.Next(100), countDown));
                }
    
                return countDown;
            }
    
            public static void Main(string[] args)
            {
                Console.WriteLine("Starting. . .");
                var stopWatch = Stopwatch.StartNew();
                CountdownEvent countdownEvent = StartTasks(100);
                countdownEvent.Wait();  // waits until the countdownEvent is signalled 100 times
                stopWatch.Stop();
                Console.WriteLine("Done! Elapsed time: {0} milliseconds", stopWatch.Elapsed.TotalMilliseconds);
            }
        }
    }
