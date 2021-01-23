    using System;
    using System.Threading;
    
    public class Test
    {
        private static bool stop = false;
    
        private static void Main()
        {
            Thread t = new Thread(DoWork);
            t.Start();
            Thread.Sleep(1000); // Let it get started
            Console.WriteLine("Setting stop flag");
            stop = true;
            Console.WriteLine("Set");
            t.Join();
        }
    
        private static void DoWork()
        {
            Console.WriteLine("Tight looping...");
            while (!stop)
            {
            }
            Console.WriteLine("Done.");
        }
    }
