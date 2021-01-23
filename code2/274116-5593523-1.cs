    public System.Timers.Timer sendTimer = new System.Timers.Timer();
    public System.Timers.Timer recTimer = new System.Timers.Timer();
    public void InitializeTimer()
    {
        // Send timer
        sendTimer.Elapsed += new ElapsedEventHandler(sendProcessTimerEvent);
        sendTimer.Interval = 3000;
        // Rec timer
        recTimer.Elapsed += new ElapsedEventHandler(recProcessTimerEvent);
        recTimer.Interval = 3000;
    }
