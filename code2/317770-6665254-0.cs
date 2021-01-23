    enum SpecialConfigurationValues
    {
        MachineName
        // , other special ones
    }
    class ConfigurationKeyAttribute : Attribute
    {
        private string _key;
        private string _value;
        public ConfigurationKeyAttribute(string key, string value)
        {
            // ...
        }
        public ConfigurationKeyAttribute(string key, SpecialConfigurationValues specialValue)
        {
            _key = key;
            switch (specialValue)
            {
                case SpecialConfigurationValues.MachineName:
                    _value = Environment.MachineName;
                    break;
                // case <other special ones>
            }
        }
    }
    [ConfigurationKey("MonitoringService", SpecialConfigurationValues.MachineName)]
