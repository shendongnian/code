    public sealed class ConfigurationServiceSection : ConfigurationSection
    {
        [ConfigurationProperty("ConfigurationServices", IsDefaultCollection = true, IsRequired = true)]
        [ConfigurationCollection(typeof(ConfigurationServices), AddItemName = "ConfigurationService")]
        public ConfigurationServices ConfigurationServices
        {
            get
            {
                return (ConfigurationServices)base["ConfigurationServices"];
            }
        }
    }
