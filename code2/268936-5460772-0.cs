    private static System.Timers.Timer _timer;
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Write a message to the event log.
        string msg = String.Format("The Elapsed event was raised at {0}", e.SignalTime);
        EventLog.WriteEntry(msg, EventLogEntryType.Information);
    }
    protected override void OnStart(string[] args)
    {
        // Create a timer with a 10-econd interval.
        _timer = new System.Timers.Timer(10000);
        // Hook up the Elapsed event for the timer.
        _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        // Signal the timer to raise Elapsed events every 10 seconds.
        _timer.Start();
    }
    protected override void OnStop()
    {
        // Stop and dispose of the timer.
        _timer.Stop();
        _timer.Dispose();
    }
