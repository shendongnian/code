        class Program
    {
        static void Main(string[] args)
        {
            Timer t1 = new Timer();
            t1.Elapsed += new ElapsedEventHandler(t1_Elapsed);
            t1.AutoReset = false;
            t1.Interval = 5000;
            t1.Start();
            while (true)
            { }
        }
        static void t1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("t1 timer elapsed");
            Timer t2 = new Timer();
            t2.Elapsed += new ElapsedEventHandler(t2_Elapsed);
            t2.AutoReset = true;
            t2.Interval = 1000;
            t2.Start();
        }
        static void t2_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("t2 timer elapsed");
        }
    }
