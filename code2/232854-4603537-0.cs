    var timer = new Timer();
    timer.Interval = 1000 * 60 * 30; // 30 mins
    timer.Tick += _timer_Tick;
    timer.Start();
    private void _timer_Tick(object sender, EventArgs e)
    {
        // log the user out, if he's logged in
    }
