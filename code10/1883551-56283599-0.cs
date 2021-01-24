    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace Sema
    {
        class Program
        {
            // do a little bit of timing magic
            static ManualResetEvent go = new ManualResetEvent(false);
    
            static void Main()
            {
                // limit the resources
                var s = new SemaphoreSlim(30, 30);
    
                // start up some threads
                var threads = new List<Thread>();
                for (int i = 0; i < 20; i++)
                {
                    var start = new ParameterizedThreadStart(dowork);
                    Thread t = new Thread(start);
                    threads.Add(t);
                    t.Start(s);
                }
    
                go.Set();
                // Wait until all threads finished
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
                Console.WriteLine();
            }
    
            private static void dowork(object obj)
            {
                go.WaitOne();
                var s = (SemaphoreSlim) obj;
                var batchsize = 3;
                // acquire tokens
                for (int i = 0; i < batchsize; i++)
                {
                    s.Wait();
                }
    
                // send the request
                Console.WriteLine("Working on a batch of size " + batchsize);
                Thread.Sleep(200);
    
                s.Release(batchsize);
            }
        }
    }
