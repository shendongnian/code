    using System;
    using System.Diagnostics;
    using System.Threading;
    class Program
    {
        static void Main()
        {
            var stopwatch = Stopwatch.StartNew();
            // Create an array of Thread references.
            Thread[] array = new Thread[4];
            for (int i = 0; i < array.Length; i++)
            {
                // Start the thread with a ThreadStart.
                array[i] = new Thread(new ThreadStart(Start));
                array[i].Start();
            }
            // Join all the threads.
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Join();
            }
            Console.WriteLine("DONE: {0}", stopwatch.ElapsedMilliseconds);
        }
    
        static void Start()
        {
            // This method takes ten seconds to terminate.
            Thread.Sleep(10000);
        }
    }
