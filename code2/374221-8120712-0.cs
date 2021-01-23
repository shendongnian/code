    private static ConfigurationProperty propIndicators = new ConfigurationProperty("indicators", typeof(ConfigurationElementCollection), null, ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection);
		
    [ConfigurationProperty("indicators", IsRequired = true, IsDefaultCollection = true)]
    [ConfigurationCollection(typeof(ReferencedConfigurationElementCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
    public ConfigurationElementCollection Indicators
    {
        get
        {
            return (ConfigurationElementCollection)this[propIndicators];
        }
        set
        {
            this[propIndicators] = value;
        }
    }
