    public static void EnsureBrowserEmulationEnabled(string exename = "YourAppName.exe", bool uninstall = false)
    {
    
        try
        {
            using (
                var rk = Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
            )
            {
                if (!uninstall)
                {
                    dynamic value = rk.GetValue(exename);
                    if (value == null)
                        rk.SetValue(exename, (uint)11001, RegistryValueKind.DWord);
                }
                else
                    rk.DeleteValue(exename);
            }
        }
        catch
        {
        }
    }
