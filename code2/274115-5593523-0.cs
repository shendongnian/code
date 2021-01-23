    public System.Timers.Timer sendTimer = new System.Timers.Timer();
    public System.Timers.Timer recTimer = new System.Timers.Timer();
    public void InitializeTimer()
    {
        //send timer
        sendTimer.Elapsed += new ElapsedEventHandler(sendProcessTimerEvent);
        sendTimer.Interval = 3000;
        //rec timer
        recTimer.Elapsed += new ElapsedEventHandler(recProcessTimerEvent);
        recTimer.Interval = 3000;
    }
