    // this must happen as soon as your program starts, before
    // you do anything else with the settings
    if (Properties.Settings.Default.UpgradeRequired)
    {
        // upgrade FIRST, before doing anything else with the settings
    
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.UpgradeRequired = false;
        Properties.Settings.Default.Save();
    }
    
    
    if (Properties.Settings.Default.IsFirstTime)
    {
        // this is the first time running the program
    
        Properties.Settings.Default.IsFirstTime = false;
        Properties.Settings.Default.Save(); 
    }
