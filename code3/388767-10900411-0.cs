        private void UpdateConfig(string key, string value, string fileName)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(fileName);
            configFile.AppSettings.Settings[key].Value = value;
            configFile.Save();
        }
