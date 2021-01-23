    using System;
    using System.Threading;
    namespace ConsoleApplication1 {
        class Program {
            static void Main() {
                // Create IO instances
                EventWaitHandle WaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset); // We don't actually fire this event, just need a ref
                EventWaitHandle StopWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                int Counter = 0;
                WaitOrTimerCallback AsyncIOMethod = (s, t) => { };
                AsyncIOMethod = (s, t) => {
                    // Handle IO step
                    Counter++;
                    Console.WriteLine(Counter);
                    if (Counter >= 10)
                        // Counter has reaced 10 so we stop
                        StopWaitHandle.Set();
                    else
                        // Register the next step in the thread pool
                        ThreadPool.RegisterWaitForSingleObject(WaitHandle, AsyncIOMethod, null, 500, true);
                };
                // Do initial IO
                Console.WriteLine(Counter);
                // Register the first step in the thread pool
                ThreadPool.RegisterWaitForSingleObject(WaitHandle, AsyncIOMethod, null, 500, true);
                // We force the main thread to wait here so that the demo doesn't close instantly
                StopWaitHandle.WaitOne();
            }
        }
    }
