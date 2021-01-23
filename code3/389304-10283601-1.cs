    class Program
    {
        static bool stop = false;
    
        public static void Main(string[] args)
        {
            var t = new Thread(() =>
            {
                Console.WriteLine("thread begin");
                bool toggle = false;
                while (!stop)
                {
                    toggle = !toggle;
                }
                Console.WriteLine("thread end");
            });
            t.Start();
            Thread.Sleep(1000);
            stop = true;
            Console.WriteLine("stop = true");
            Console.WriteLine("waiting...");
            t.Join();
        }
    }
