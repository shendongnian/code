    public static class TimerHelper
    {
        private static Timer _timer;
    
        static TimerHelper()
        {
            _timer = new Timer(){AutoReset=true, Interval=1000};
            _timer.Start();
        }
    
        public static event ElapsedEventHandler Elapsed
        {
            add { _timer.Elapsed += value; } 
            remove { _timer.Elapsed -= value; }
        }
    }
