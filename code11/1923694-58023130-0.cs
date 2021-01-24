    class MyTimer
    {
        // Is there a reason you want this timer to be public? Otherwise make it private.
        public static Timer timer;
    
        public event EventHandler<ElapsedEventArgs> OnTimerEvent;
    
        public MyTimer()
        {
            timer = new Timer();
        }
    
        private static void OnTimedEvent(Object sender, ElapsedEventArgs e)
        {
            OnTimerEvent?.Invoke(this, e);
        }
    }
