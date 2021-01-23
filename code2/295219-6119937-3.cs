    using System;
    using System.Threading;
    
    static class Program
    {
        private static Timer timer = new Timer(TimerCallBack); 
        private static bool changed = false;
    
        public static void Main()
        {
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Thread.Sleep(10000);
            
        }
    
        private static void TimerCallBack(object obj)
        {
            Console.WriteLine("{0}: Fired", DateTime.Now);
            if (!changed)
            {
                changed = true;
                TimeSpan interval = TimeSpan.FromSeconds(3);
                timer.Change(interval, interval);
            }
        }
    }
