     1: // Open App.Config of executable   
     2: System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);   
     3: // Add an Application Setting.   
     4: config.AppSettings.Settings.Remove("LastDateChecked");   
     5: config.AppSettings.Settings.Add("LastDateChecked", DateTime.Now.ToShortDateString());   
     6: // Save the configuration file.   
     7: config.Save(ConfigurationSaveMode.Modified);   
     8: // Force a reload of a changed section.   
     9: ConfigurationManager.RefreshSection("appSettings");
