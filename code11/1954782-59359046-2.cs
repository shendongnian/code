    public void OnClosing()
    {
        MainWindowSettingsProvider settingsProvider = MainWindowSettingsProvider.Instance;
        settingsProvider.MainWindowSettings.WindowPlacementInfo = ((Window)View).GetPlacement();
        settingsProvider.Save();
    }
    
