    public class ConfigMan
    {
        #region Members
        string _assemblyLocation;
        Configuration _configuration;
        #endregion Members
        #region Constructors
        /// <summary>
        /// Loads config file settings for libraries that use assembly.dll.config files
        /// </summary>
        /// <param name="assemblyLocation">The full path or UNC location of the loaded file that contains the manifest.</param>
        public ConfigMan(string assemblyLocation)
        {
            _assemblyLocation = assemblyLocation;
        }
        #endregion Constructors
        #region Properties
        Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    try
                    {
                        _configuration = ConfigurationManager.OpenExeConfiguration(_assemblyLocation);
                    }
                    catch (Exception exception)
                    {
                    }
                }
                return _configuration;
            }
        }
        #endregion Properties
        #region Methods
        public string GetAppSetting(string key)
        {
            string result = string.Empty;
            if (Configuration != null)
            {
                KeyValueConfigurationElement keyValueConfigurationElement = Configuration.AppSettings.Settings[key];
                if (keyValueConfigurationElement != null)
                {
                    string value = keyValueConfigurationElement.Value;
                    if (!string.IsNullOrEmpty(value)) result = value;
                }
            }
            return result;
        }
        #endregion Methods
    }
