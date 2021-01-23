    public static void FixBrowserVersion2(string root, string appName, int lvl)
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
