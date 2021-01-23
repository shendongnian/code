    if (Properties.Settings.Default.CallUpgrade)
    {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.Reload(); // to activate the settings
        Properties.Settings.Default.CallUpgrade = false;
        Properties.Settings.Default.Save();// to save the new value of CallUpgrade            
    }
