    using System;
    using System.IO;
    using System.Timers;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            public static Timer SystemTimer { get; set; }
            public static double Elapsed { get; set; }
    
            private const double CycleInterval = 1000;
    
            static void Main(string[] args)
            {
                SystemTimer = new Timer();
                SystemTimer.Interval = CycleInterval;
                SystemTimer.Enabled = true;
                SystemTimer.Elapsed += Cycle;
    
                SystemTimer.Start();
    
                while (true) ;
    
            }
    
            static void Cycle(object sender, ElapsedEventArgs e)
            {
                Elapsed += CycleInterval;
    
                if ((Elapsed%5000) == 0.0)
                {
                    Console.WriteLine("5 sec elapsed!");
                    // Do stuff each 5 sec
                }
    
                if ((Elapsed % 10000) == 0.0)
                {
                    Console.WriteLine("10 sec elapsed!");
                    // Do stuff each 10 sec
                }
    
                Console.WriteLine("Elapsed: {0}", Elapsed);
            }
        }
    }
