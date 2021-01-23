    private static Timer _timer;
    protected override void OnStart(string[] args)
    {
        _timer = new Timer(); //This will set the default interval
        _timer.AutoReset = false;
        _timer.Elapsed = OnTimer;
        _timer.Start();
    }
    private void OnTimer(object sender, ElapsedEventArgs args)
    {
        //Do some work here
        _timer.Stop();
        _timer.Interval = 50000; //Set your new interval here
        _timer.Start();
    }
