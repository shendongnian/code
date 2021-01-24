    class MyTimer
    {
        private readonly Action _userAction;
        private Timer timer;
    
        public MyTimer(Action userAction)
        {
            _userAction = userAction;
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
        }
    
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _userAction?.Invoke();
        }
    }
