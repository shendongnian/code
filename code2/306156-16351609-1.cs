    public static void Main(string[] args)
        {
            // Get Root
            var root = Registry.ClassesRoot;
    
            // Get the Applications key
            var applicationsSubKey = root.OpenSubKey("Applications", true);
    
            if (applicationsSubKey != null)
            {
                bool updateNoStartPageKey = false;
    
                // Check to see if your application already has a key created in the Applications key
                var appNameSubKey = applicationsSubKey.OpenSubKey("MyAppName.exe", true);
    
                if (appNameSubKey != null)
                {
                    // Check to see if the NoStartPage value has already been created
                    if (!appNameSubKey.GetValueNames().Contains("NoStartPage"))
                    {
                        updateNoStartPageKey = true;
                    }
                }
                else
                {
                    // create key for your application in the Applications key under Root
                    appNameSubKey = applicationsSubKey.CreateSubKey("MyAppName.exe", RegistryKeyPermissionCheck.Default);
    
                    if (appNameSubKey != null)
                    {
                        updateNoStartPageKey = true;
                    }
                }
    
                if (updateNoStartPageKey)
                {
                    // Create/update the value for NoStartPage so Windows will prevent the app from being pinned.
                    appNameSubKey.SetValue("NoStartPage", string.Empty, RegistryValueKind.String);                    
                }
            }
        }
