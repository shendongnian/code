    class Program
    {
        private static Process p1 = new Process();
        static void Main()
        {
            Console.WriteLine("Main is running in thread {0}", Thread.CurrentThread.ManagedThreadId);
            var t1 = new Thread(Helper);
            t1.Start();
            Console.ReadLine();
        }
        private static Helper( )
        {
            p.Run();
            p.Fnc();
        }
    }
