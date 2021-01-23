    public class TestConfigurationSection : ConfigurationSection
    {
        [ConfigurationCollection(typeof (TestConfigurationElement), AddItemName = "test")]
        [ConfigurationProperty("Tests", IsDefaultCollection = true)]
        public TestConfigurationElementCollection Tests
        {
            get { return (TestConfigurationElementCollection)this["Tests"]; }
        }
    }
