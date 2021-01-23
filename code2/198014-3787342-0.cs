    Microsoft.Win32.SystemEvents.TimeChanged += 
        new EventHandler(SystemEvents_TimeChanged);
    void SystemEvents_TimeChanged(object sender, EventArgs e)
    {
        // The system time was changed
    }
