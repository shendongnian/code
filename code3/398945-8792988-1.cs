    StopWatchTimer.Interval = 1; 
    StopWatchTimer.Enabled = true; 
    StopWatchTimer.AutoReset = true; 
    StopWatchTimer.Elapsed += new System.Timers.ElapsedEventHandler(StopWatchTimer_Tick); 
    StopWatchTimer.Start(); 
