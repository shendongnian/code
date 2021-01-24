    string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    string configFile = System.IO.Path.Combine(appPath, "app.config");
    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
    configFileMap.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
    System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
    config.AppSettings.Settings["yourkey"].Value = //your value
    config.Save();
    ConfigurationManager.RefreshSection("appSettings");
