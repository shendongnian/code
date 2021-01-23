    private string GetRegistryKeyPathForX()
    {
        var adobe = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Adobe");
        if (adobe == null)
        {
            return string.Empty;
        }
        RegistryKey acroRead = adobe.OpenSubKey("Adobe Acrobat");
        if (acroRead == null)
        {
            return string.Empty;
        }
        string[] acroReadVersions = acroRead.GetSubKeyNames();
        //The following version(s) of Acrobat Reader are installed
        foreach (string versionNumber in acroReadVersions)
        {
            switch (versionNumber)
            {
                case "6.0": return "Software\\Adobe\\Acrobat Reader";
                case "7.0": return "";
                case "8.0": return "";
                case "9.0": return "Software\\Adobe\\Acrobat Reader";
                default:	break;
            }
        }
        return "ERR_KEY";
    }
