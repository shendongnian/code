    Timer miniClock = new Timer();
    private void btnStartTimer_Click(object sender, EventArgs e)
    {           
        miniClock.Interval = 1000;
        miniClock.Tick += new EventHandler(MiniClockEventProcessor);
        miniClock.Start();
    }
    private void MiniClockEventProcessor(Object myObject, EventArgs myEventArgs)
    {
        if (notifyIcon1.Icon == AlertIcon)
        {
            notifyIcon1.Icon = LogoIcon;
        }
        else
            notifyIcon1.Icon = AlertIcon;
    }
    private void btnStopTimer_Click(object sender, EventArgs e)
    {
        miniClock.Stop();
        btnTest.Enabled = true;
    }
