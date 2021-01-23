     // Open App.Config of executable
     System.Configuration.Configuration config = 
     ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
     // Add an Application Setting.
     config.AppSettings.Settings.Remove("LastDateFeesChecked");
     config.AppSettings.Settings.Add("LastDateFeesChecked",    
     DateTime.Now.ToShortDateString());
     // Save the configuration file.
     config.Save(ConfigurationSaveMode.Modified);
     // Force a reload of a changed section.
    ConfigurationManager.RefreshSection("appSettings");
