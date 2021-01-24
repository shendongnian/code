    using System;
    using System.Threading;
    using System.Timers;
    
    namespace Timer
    {
        class Program
        {
            static void Main(string[] args)
            {
                int counter = 0;
    
                while (Console.Read() != 'q')
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 1000;
                    aTimer.AutoReset = false
                    aTimer.Start();
    
                    Console.WriteLine("Thread about to sleep");
                    Thread.Sleep(3000);
                    Console.WriteLine("Thread woke up");
    
    
                    if (counter > 0)
                    {
                        aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                    }
    
                    ++counter;
                }
    
    
                //System.Timers.Timer aTimer = new System.Timers.Timer();
                //aTimer.Start();
    
                //Thread.Sleep(1000);
    
                //System.Timers.Timer aTimer2 = new System.Timers.Timer();
                //aTimer2.Start();
    
                //aTimer.
    
                //diff = aTimer2 - aTimer; 
    
                //if()
    
    
                //DateTime time1 = DateTime.Now;
                //Thread.Sleep(1000);
                ////DateTime time2 = DateTime.Now;
    
                //System.TimeSpan diff = time2 - time1;
    
                //if (diff < (System.TimeSpan)3000)
                //{
                //    Console.WriteLine("Hello"); 
    
                //}
    
                //Console.WriteLine("Press \'q\' to quit the sample.");
                // while (Console.Read() != 'q') ;
            }
    
            // Specify what you want to happen when the Elapsed event is raised.
            private static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                Console.WriteLine("Hello World!");
                
            }
        }
    }
