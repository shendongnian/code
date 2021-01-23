    public static System.Configuration.Configuration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel)
    {
        return OpenExeConfigurationImpl(fileMap, false, userLevel, null);
    }
        
    public static System.Configuration.Configuration OpenExeConfiguration(string exePath)
    {
        return OpenExeConfigurationImpl(null, false, ConfigurationUserLevel.None, exePath);
    }
