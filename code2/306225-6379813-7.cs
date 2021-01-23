    private System.Timers.Timer _timer = new System.Timers.Timer();
    private volatile bool _requestStop = false;
    
    public constructor()
    {
        _timer.Interval = 100;
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = false;
        _timer.Start();
    }
    
    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // do work....
        if (!_requestStop)
        {
            _timer.Start();//restart the timer
        }
    }
    
    private void Stop()
    {
        _requestStop = true;
        _timer.Stop();
    }
    
    private void Start()
    {
        _requestStop = false;
        _timer.Start();
    }
