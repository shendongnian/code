    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            var t = new Thread(() =>
            {
                try { Console.WriteLine("hi"); } finally { while (true) { i++; } }
            });
            t.Start();
            Thread.Sleep(1000);
            t.Abort();
            Console.WriteLine("Success. {0}", i);
            Console.ReadKey();
        }
    }
