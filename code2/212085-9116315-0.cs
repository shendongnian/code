    var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Reflection.Assembly.GetExecutingAssembly().Location);
    typeof(Configuration.ConfigurationElementCollection).GetField("bReadOnly", Reflection.BindingFlags.Instance | Reflection.BindingFlags.NonPublic).SetValue(System.Configuration.ConfigurationManager.ConnectionStrings, false);
    foreach (Configuration.ConnectionStringSettings conn in config.ConnectionStrings.ConnectionStrings)
	    System.Configuration.ConfigurationManager.ConnectionStrings.Add(conn);
    foreach (Configuration.KeyValueConfigurationElement conf in config.AppSettings.Settings)
	    System.Configuration.ConfigurationManager.AppSettings(conf.Key) = conf.Value;
