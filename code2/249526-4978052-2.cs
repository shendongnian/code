    class Program
    {
        static void Main(string[] args)
        {
            var mre = new ManualResetEvent(false);
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                new Thread(() =>
                {
                    Console.WriteLine("Started {0}", j);
                    mre.WaitOne();
                    Console.WriteLine("Continued {0}", j); 
                }).Start();
            }
            mre.Set();
            Console.ReadLine();
        }
    }
