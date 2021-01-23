    public class StandardConfigSectionHandler : ConfigurationSection
    {
        private const string ConfigPath = "ConfigSectionGroup/ConfigSection";
        public static StandardConfigSectionHandler GetConfiguration()
        {
            return (StandardConfigSectionHandler)ConfigurationManager.GetSection(ConfigPath);
        }
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
