    using System;
    using System.Threading;
    class Program
    {
        static Timer timer;
        static void Main(string[] args)
        {
            timer = new Timer(new TimerCallback(DoWork), null, 1000, 1000);
            Console.ReadKey();
            timer = null;
            Console.ReadKey();
        }
        static void DoWork(object state)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
