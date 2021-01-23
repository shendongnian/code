    static class Settings
    {
        static UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
        static Configuration myDllConfig = ConfigurationManager.OpenExeConfiguration(uri.Path);
        static AppSettingsSection AppSettings = (AppSettingsSection)myDllConfig.GetSection("appSettings");
        static NumberFormatInfo nfi = new NumberFormatInfo() 
        { 
            NumberGroupSeparator = "", 
            CurrencyDecimalSeparator = "." 
        };
        public static T Setting<T>(string name)
        {
            return (T)Convert.ChangeType(AppSettings.Settings[name].Value, typeof(T), nfi);
        }
    }
