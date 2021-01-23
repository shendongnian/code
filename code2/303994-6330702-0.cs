       private static string readConfig(string value)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            System.Configuration.AppSettingsSection ass = config.AppSettings;
            foreach (System.Configuration.KeyValueConfigurationElement item in ass.Settings)
            {
                if (item.Value == value)
                    return item.Key;
            }
            return null;
        }
