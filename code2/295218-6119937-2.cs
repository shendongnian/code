    using System;
    using System.Threading;
    
    static class Program
    {
        private static Timer timer = new Timer(TimerCallBack); 
    
        public static void Main()
        {
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Thread.Sleep(10000);
            
        }
    
        private static void TimerCallBack(object obj)
        {
            Console.WriteLine("{0}: Fired", DateTime.Now);
            timer.Change(TimeSpan.FromSeconds(3),
                         TimeSpan.FromMilliseconds(Timeout.Infinite));
        }
    }
