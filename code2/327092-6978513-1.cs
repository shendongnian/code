    private void GetConfigurationSettings(TargetEnvironments targetEnvironment)
		{
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var databases = new Hashtable();
			var storageSystems = new Hashtable();
			switch (targetEnvironment)
			{
				case TargetEnvironments.QA:
					databases = (Hashtable)ConfigurationManager.GetSection("Environment/QA/databases");
					storageSystems = (Hashtable)ConfigurationManager.GetSection("Environment/QA/storageSystems");
					break;
				case TargetEnvironments.PROD:
					databases = (Hashtable)ConfigurationManager.GetSection("Environment/PROD/databases");
					storageSystems = (Hashtable)ConfigurationManager.GetSection("Environment/PROD/storageSystems");
					break;
			}
			foreach (string key in databases.Keys) { config.AppSettings.Settings.Add(key, databases[key].ToString()); }
			foreach (string key in storageSystems.Keys) { config.AppSettings.Settings.Add(key, storageSystems[key].ToString()); }
			config.Save(ConfigurationSaveMode.Modified);
			
			ConfigurationManager.RefreshSection("appSettings");
			UpdateCollections();
		}
 
