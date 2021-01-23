    public class ConfigManager
    {
        private static readonly ClientSection _clientSection = null;
        private static readonly AppSettingsSection _appSettingSection = null;
        private static readonly ConnectionStringsSection _connectionStringSection = null;
        private const string CONFIG_PATH = @"..\..\..\The rest of your path\web.config";
    
        static ConfigManager()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = CONFIG_PATH
            };
    
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
    
            _clientSection = config.GetSection("system.serviceModel/client") as ClientSection;
            _appSettingSection = config.AppSettings;
            _connectionStringSection = config.ConnectionStrings;
        }
    
        public string GetClientEndpointConfigurationName(Type t)
        {
            string contractName = t.FullName;
            string name = null;
    
            foreach (ChannelEndpointElement c in _clientSection.Endpoints)
            {
                if (string.Compare(c.Contract, contractName, true) == 0)
                {
                    name = c.Name;
                    break;
                }
            }
    
            return name;
        }
    
        public string GetAppSetting(string key)
        {
            return _appSettingSection.Settings[key].Value;
        }
    
        public string GetConnectionString(string name)
        {
            return _connectionStringSection.ConnectionStrings[name].ConnectionString;
        }
    }
