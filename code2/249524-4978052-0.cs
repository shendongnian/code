    class Program
    {
        static void Main(string[] args)
        {
            var are = new AutoResetEvent(false);
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                new Thread(() =>
                {
                    Console.WriteLine("Started {0}", j);
                    are.WaitOne();
                    Console.WriteLine("Continued {0}", j); 
                }).Start();
            }
            are.Set();
            Console.ReadLine();
        }
    }
