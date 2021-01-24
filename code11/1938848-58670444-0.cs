    LogManager.ConfigurationChanged += LogManager_ConfigurationChanged;
    
    private static void LogManager_ConfigurationChanged(object sender, LoggingConfigurationChangedEventArgs e)
    {
        System.Diagnostics.Trace.WriteLine("Configuration was changed");
    }
