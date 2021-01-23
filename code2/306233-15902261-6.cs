    void StartTimer()
    {
        TimerHelper _timerHelper = new TimerHelper();
        _timerHelper.TimerEvent += (timer,state) => Timer_Elapsed();
        _timerHelper.Start(TimeSpan.FromSeconds(5));
        System.Threading.Sleep(TimeSpan.FromSeconds(12));
        _timerHelper.Stop();
    }
    
    void Timer_Elapsed()
    {
       // Do what you want to do
    }
