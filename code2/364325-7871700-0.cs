    System.Timers.Timer _timer = new  System.Timers.Timer();
    _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
    //30 seconds
    _overruledInstancesTimer.Interval = 30000;
    _overruledInstancesTimer.Start();
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //do your logic
    }
