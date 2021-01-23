    System.Timers.Timer timer = new System.Timers.Timer();
    timer = new System.Timers.Timer();
    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    timer.Interval = 5000;
    timer.Start();
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //do the logic..
    }
