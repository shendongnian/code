    using System;
    using System.Threading;
    
    public class Test
    {
        private static bool stop = false;
    
        private bool Stop
        {
            get { return stop; }
            set { stop = value; }
        }
        private static void Main()
        {
            Thread t = new Thread(DoWork);
            t.Start();
            Thread.Sleep(1000); // Let it get started
            Console.WriteLine("Setting stop flag");
            Stop = true;
            Console.WriteLine("Set");
            t.Join();
        }
    
        private static void DoWork()
        {
            Console.WriteLine("Tight looping...");
            while (!Stop)
            {
            }
            Console.WriteLine("Done.");
        }
    }
