    static void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
    {
        if (e.Mode == Microsoft.Win32.PowerModes.StatusChange)
        {
             // Check what the status is and act accordingly
        }
    }
