    // FixBrowserVersion("<YourAppName>", 9000);
    public static void FixBrowserVersion(string appName, int lvl)
    {
        FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".exe", lvl);
        FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".exe", lvl);
        FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".vshost.exe", lvl);
        FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".vshost.exe", lvl);
    }
    
    
    private static void FixBrowserVersion_Internal(string root, string appName, int lvl)
    {
        try
        {
    
            Microsoft.Win32.Registry.SetValue(root + @"\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, lvl);
        }
        catch (Exception)
        {
            // some config will hit access rights exceptions
            // this is why we try with both LOCAL_MACHINE and CURRENT_USER
        }
    }
