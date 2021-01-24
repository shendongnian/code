    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                throttleTimer.Start();
                // This loop simulates your periodic check to see if the action
                // needs to be performed:
                while (true)
                {
                    doActionIfTimeElapsed(TimeSpan.FromSeconds(5));
                    Thread.Sleep(1000);  // Simulate checking every 1 second or so.
                }
            }
            static Stopwatch throttleTimer = new Stopwatch();
            static void doActionIfTimeElapsed(TimeSpan period)
            {
                if (throttleTimer.Elapsed <= period)
                    return;
                doAction();
                throttleTimer.Restart();
            }
            static void doAction()
            {
                Console.WriteLine("Doing the action.");
            }
        }
    }
