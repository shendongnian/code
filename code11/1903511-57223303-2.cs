    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace LockingTest
    {
        class Program
        {
            public static object locker = new object();
            public static Mutex mutex = new Mutex();
            public static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            static void Main(string[] args)
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                for (int i = 0; i < 10000000; i++)
                {
                    mutex.WaitOne(); // we are testing mutex time overhead
                    mutex.ReleaseMutex();
                }
                sw.Stop();
                Console.WriteLine("Mutex :" + "  proccess time token " + sw.Elapsed.ToString() + " miliseconds");
                Thread.Sleep(1000); // let os to be idle 
                sw.Restart();
                for (int i = 0; i < 10000000; i++)
                {
                    lock (locker) { } // we are testing lock time overhead
                }
                sw.Stop();
                Console.WriteLine("Lock :" + "  proccess time token " + sw.Elapsed.ToString() + " miliseconds");           
                Console.ReadLine();
            }
        }
    }
