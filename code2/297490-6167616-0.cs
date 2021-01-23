     private static void SaveConfig(string KeyName, string value)
        {
            System.Configuration.ConfigurationManager.AppSettings[KeyName] = value;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            System.Configuration.AppSettingsSection ass = config.AppSettings;
            if (ass.Settings[KeyName] != null)
                ass.Settings[KeyName].Value = value;
            else
                ass.Settings.Add(KeyName, value);
            config.Save();
        }
