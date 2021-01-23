      public static void SetAppSettingValue(string Key, string Value)
       {
               
       System.Configuration.Configuration config == ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    // Add an Application Setting.
           
     config.AppSettings.Settings[Key].Value = Value;
           
      // Save the changes in App.config file.
            
       config.Save(ConfigurationSaveMode.Modified);
           
        ConfigurationManager.RefreshSection("appSettings");
      }
