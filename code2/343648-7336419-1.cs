      private string GetSettingValue(string key)
      {
         string executingAssembly = Assembly.GetEntryAssembly().GetName().Name;
         string sectionName = "applicationSettings/" + executingAssembly 
                                                     + ".Properties.Settings";
         ClientSettingsSection section =
                (ClientSettingsSection)ConfigurationManager.GetSection(sectionName);
         
         // add null checking etc
         SettingElement setting = section.Settings.Get(key); 
         return setting.Value.ValueXml.InnerText;
      }
