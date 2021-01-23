    // Create an instance of IsolatedStorageSettings.
    private IsolatedStorageSettings userSettings =
        IsolatedStorageSettings.ApplicationSettings;
    
    // Add a key and its value.
    userSettings.Add("userImage", "BlueHills.jpg");
    
    // Remove the setting.
    userSettings.Remove("userImage");
