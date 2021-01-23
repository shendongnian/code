    [ConfigurationCollection(typeof(TestConfigurationElement), AddItemName = "test")]
    public class TestConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TestConfigurationElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TestConfigurationElement)element).Name;
        }
    }
