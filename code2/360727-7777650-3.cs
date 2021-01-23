     /// <summary>
    /// This will read config.ini file and return the specific value
    /// </summary>
    /// <param name="MainSection">Main catergory name</param>
    /// <param name="key">name of the key in main catergory</param>
    /// <param name="defaultValue">if key is not in the section, then default value</param>
    /// <returns></returns>
    public static string getIniValue(string MainSection, string key, string defaultValue)
    {
      IniFile inif = new IniFile(AppDataPath() + @"\config.ini");
      string value = "";
      value = (inif.IniReadValue(MainSection, key, defaultValue));
      return value;
    }
    
    public static string AppDataPath()
    {
      gCommonAppDataPath = @"c:\" + gCompanyName + @"\" + gProductName; // your config file location path
      return gCommonAppDataPath;
    }
