    internal class ThreadInterruptFinally
    {
        public static void Do()
        {
            Thread t = new Thread(ProcessSomething) { IsBackground = false };
            t.Start();
            Thread.Sleep(500);
            t.Interrupt();
            t.Join();
        }
        private static void ProcessSomething()
        {
            try
            {
                Console.WriteLine("processing");
            }
            finally
            {
                Thread.Sleep(2 * 1000);
            }
            Console.WriteLine("Exited finally...");
            Thread.Sleep(0); //<-- ThreadInterruptedException
        }
    }   
