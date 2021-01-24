    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(() =>
            {
                try { Console.WriteLine("hi"); } finally { while (true) { Console.WriteLine("ho"); } }
            });
            t.Start();
            Thread.Sleep(1000);
            t.Abort();
            Console.WriteLine("Success.");
            Console.ReadKey();
        }
    }
