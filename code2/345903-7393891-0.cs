    public static string GetAppSetting(string key)
    {
        var result = ConfigurationManager.AppSettings[key].ToString();
        Trace.TraceInformation(String.Format("Config.GetAppSetting - Key: {0}, Result: {1}", key, result));
        return result;
    }
