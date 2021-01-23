    public static void OpenWebsite(string url)
    { 
        Process.Start(GetDefaultBrowserPath(), url);
    }
    
    private static string GetDefaultBrowserPath()
    {
        string key = @"http\shell\open\command";
        RegistryKey registryKey =
        Registry.ClassesRoot.OpenSubKey(key, false);
        return ((string)registryKey.GetValue(null, null)).Split('"')[1];
    }
