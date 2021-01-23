    class ConfigManager
    {
        public static string GetSetting(string name)
        {
            return ConfigurationManager.AppSettings[name].ToString();
        }
    }
