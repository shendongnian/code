    string configFilePath = ".../App";
	System.Configuration.Configuration newConfiguration = ConfigurationManager.OpenExeConfiguration(configFilePath);
	FieldInfo configSystemField = typeof(ConfigurationManager).GetField("configSystem", BindingFlags.NonPublic | BindingFlags.Static);
	object configSystem = configSystemField.GetValue(null);
	FieldInfo cfgField = configSystem.GetType().GetField("cfg", BindingFlags.Instance | BindingFlags.NonPublic);
	cfgField.SetValue(configSystem, newConfiguration);
