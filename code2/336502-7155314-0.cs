    public string GetKeyThatHasMyValue (string ValueToFind)
    {
        string Result = null;
        foreach (string Key in ConfigurationManager.AppSettings.Keys)
        {
            if (ConfigurationManager.AppSettings[Key].Contains (ValueToFind))
            {
                Result = Key;
                break;
            }
        }
        return Result;
     }
