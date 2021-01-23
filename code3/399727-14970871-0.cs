        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadFunc));
            t.Start();
            Console.WriteLine("Hit any key to exit.");
            Console.ReadLine();
            Console.WriteLine("App exiting");
            return;
        }
        static void ThreadFunc()
        {
            int i=0;
            try
            {
                while (true)
                {
                    Console.WriteLine(Thread.CurrentThread.ThreadState.ToString() + " " + i);
                    Thread.Sleep(1000 * 10);
                    i++;
                }
            }
            finally
            {
                Console.WriteLine("Exiting while loop");
            }
            return;
        }
