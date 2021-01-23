    public class MySection : ConfigurationSection
    {
        protected static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();
        private static ConfigurationProperty propElements = new ConfigurationProperty("elements", typeof(MyElementCollection), null, ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection);
        static BotSection()
        {
            properties.Add(propElements);
        }
        [ConfigurationProperty("elements", DefaultValue = null, IsRequired = true)]
        [ConfigurationCollection(typeof(MyElementCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public MyElementCollection Elements
        {
            get
            {
                return (MyElementCollection)this[propElements];
            }
            set
            {
                this[propElements] = value;
            }
        }
    }
    
    public class MyElementCollection : ConfigurationElementCollection, 
                                       IEnumerable<ConfigurationElement> // most important difference with default solution
    {
        ...
    }
    
    public class MyElement : ConfigurationElement
    {
        protected static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();
        private static ConfigurationProperty propValue= new ConfigurationProperty("value", typeof(int), -1, ConfigurationPropertyOptions.IsRequired);
        public int Value
        {
            get
            {
                return (int)this[propValue];
            }
            set
            {
                this[propValue] = value;
            }
        }
    }
