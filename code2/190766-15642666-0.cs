    var configPath = YOUR_PATH;
    if (!Directory.Exists(ProductFolder))
    {
        Directory.CreateDirectory(ProductFolder);
    }
    if (!File.Exists(configPath))
    {
        File.WriteAllText(configPath, Resources.App);
    }
    var map = new ExeConfigurationFileMap
    {
        ExeConfigFilename = configPath,
        LocalUserConfigFilename = configPath,
        RoamingUserConfigFilename = configPath
    };
    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
