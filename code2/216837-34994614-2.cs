    /// <summary>
    /// Creates a custom configuration section inside web.config
    /// </summary>
    public class QueryConfigurationSection : ConfigurationSection
    {
        //query 2
        [ConfigurationProperty("Query1")]
        public QueryElement1 Query1
        {
            get { return this["Query1"] as QueryElement1; }
        }
    
        //query 2
        [ConfigurationProperty("Query2")]
        public QueryElement2 Query2
        {
            get { return this["Query2"] as QueryElement2; }
        }
    }
    public class QueryElement1 : ConfigurationElement
    {
        public string Value { get; private set; }
        protected override void DeserializeElement(XmlReader reader, bool s)
        {
            Value = reader.ReadElementContentAs(typeof(string), null) as string;
        }        
    }
    public class QueryElement2 : ConfigurationElement
    {
        public string Value { get; private set; }
        protected override void DeserializeElement(XmlReader reader, bool s)
        {
            Value = reader.ReadElementContentAs(typeof(string), null) as string;
        }
    }
