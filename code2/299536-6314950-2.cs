    public class TestConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public TestConfigurationElementCollection Tests
        {
            get { return (TestConfigurationElementCollection)this[""]; }
        }
    }
