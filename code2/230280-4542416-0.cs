    public static class LogFactory
    {
        public const string ConfigFileName = "log4net.config";
        public static void Configure()
        {
            Type type = typeof(LogFactory);
            FileInfo assemblyDirectory = AssemblyInfo.GetCodeBaseDirectory(type);
            string path = Path.Combine(assemblyDirectory.FullName, ConfigFileName);
            FileInfo configFile = new FileInfo(path);
            XmlConfigurator.ConfigureAndWatch(configFile);
            log4net.ILog log = LogManager.GetLogger(type);
            log.ToString();
        }
    }
