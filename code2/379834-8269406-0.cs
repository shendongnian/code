    public class Body : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "Body", IsKey = true, IsRequired = true)]
        public string Value{get;set;}
    }
