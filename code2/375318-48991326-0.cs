        using System.Configuration;
        /// <summary>
        /// For read one setting
        /// </summary>
        /// <param name="key">Key correspondent a your setting</param>
        /// <returns>Return the String contains the value to setting</returns>
        public string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            return appSettings[key] ?? string.Empty;
        }
        /// <summary>
        /// Read all settings for output Dictionary<string,string> 
        /// </summary>        
        /// <returns>Return the Dictionary<string,string> contains all settings</returns>
        public Dictionary<string, string> ReadAllSettings()
        {
            var result = new Dictionary<string, string>();
            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
                result.Add(key, ConfigurationManager.AppSettings[key]);
            return result;
        }
