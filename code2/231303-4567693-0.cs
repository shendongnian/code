    public abstract class ProviderConfiguration : ConfigurationSection
    {
        public string ConfigurationSectionName { get; set; }
    
        public static ProviderConfiguration Provider { get; set; }
    
        public static Configuration Current
        {
            get { return (Configuration)ConfigurationManager.GetSection(Provider.ConfigurationSectionName); }
        }
    }
