    public bool setSetting(string pstrKey, string pstrValue)
    {
        Configuration objConfigFile =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        bool blnKeyExists = false;
        foreach (string strKey in objConfigFile.AppSettings.Settings.AllKeys)
        {
            if (strKey == pstrKey)
            {
                blnKeyExists = true;
                objConfigFile.AppSettings.Settings[pstrKey].Value = pstrValue;
                break;
            }
        }
        if (!blnKeyExists)
        {
            objConfigFile.AppSettings.Settings.Add(pstrKey, pstrValue);
        }
        objConfigFile.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
        return true;
    }
