    public string GetKeyThatHasMyValue (string Section, string ValueToFind)
    {
        string Result = null;
        var Settings = (NameValueCollection)ConfigurationManager.GetSection (Section);
        foreach (string Key in Settings.Keys)
        {
            if (Settings[Key].Contains (ValueToFind))
            {
                Result = Key;
                break;
            }
        }
        return Result;
     }
