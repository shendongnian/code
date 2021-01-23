    int languageCode = 1033; //Default to english
    const string keyEntry = "UILanguage";
    if (IsOutlook2010)
    {
        const string reg = @"Software\Microsoft\Office\14.0\Common\LanguageResources";
        try
        {
            RegistryKey k = Registry.CurrentUser.OpenSubKey(reg);
            if (k != null && k.GetValue(keyEntry) != null) languageCode = (int)k.GetValue(keyEntry);
        } catch { }
        try
        {
            RegistryKey k = Registry.LocalMachine.OpenSubKey(reg);
            if (k != null && k.GetValue(keyEntry) != null) languageCode = (int)k.GetValue(keyEntry);
        } catch { }
    }
    else
    {
        const string reg = @"Software\Microsoft\Office\12.0\Common\LanguageResources";
        try
        {
            RegistryKey k = Registry.CurrentUser.OpenSubKey(reg);
            if (k != null && k.GetValue(keyEntry) != null) languageCode = (int)k.GetValue(keyEntry);
        } catch { }
        try
        {
            RegistryKey k = Registry.LocalMachine.OpenSubKey(reg);
            if (k != null && k.GetValue(keyEntry) != null) languageCode = (int)k.GetValue(keyEntry);
        } catch { }
    }
    Resource1.Culture = new CultureInfo(languageCode);
