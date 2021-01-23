    // read the Test1 value from the config file
    string test1 = ConfigSettings.ReadSetting("Test1");
    
    // write a new value for the Test1 setting
    ConfigSettings.WriteSetting("Test1", "This is my new value");
    
    // remove the Test1 setting from the config file
    ConfigSettings.RemoveSetting("Test1");
