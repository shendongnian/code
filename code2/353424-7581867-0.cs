    // Add an Application Setting.
           
     config.AppSettings.Settings[Key].Value = Value;
           
      // Save the changes in App.config file.
            
       config.Save(ConfigurationSaveMode.Modified);
           
        ConfigurationManager.RefreshSection("appSettings");
      }
