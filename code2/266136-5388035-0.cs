    using System;
    using System.Threading;
    
    public class A  
    {
        static void Main()
        {
            // Start off unpaused
            var sharedEvent = new ManualResetEvent(true);
    
            for (int i = 0; i < 4; i++)
            {
                string prefix = "Thread " + i;
                Thread t = new Thread(() => DoFakeWork(prefix,
                                                       sharedEvent));
                // Let the process die when Main finished
                t.IsBackground = true;
                t.Start();
            }
            // Let the workers work for a while
            Thread.Sleep(3000);
            Console.WriteLine("Pausing");        
            sharedEvent.Reset();
            
            Thread.Sleep(3000);       
            Console.WriteLine("Resuming");
            sharedEvent.Set();
            
            Thread.Sleep(3000);
            Console.WriteLine("Finishing");
        }
        
        static void DoFakeWork(string prefix, ManualResetEvent mre)
        {
            while (true)
            {
                Console.WriteLine(prefix + " working...");
                Thread.Sleep(500);
                mre.WaitOne();
            }
        }
    }
