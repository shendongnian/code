    System.Timers.Timer _timer = new  System.Timers.Timer();
    _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
    //30 seconds
    _timer.Interval = 30000;
    _timer.Start();
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //do your logic
    }
