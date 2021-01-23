    public class MyConfig : ConfigurationSection
    {
        public MyConfig()
        {
            // throw some code in here to retrieve your XML from your database
            // deserialize your XML and store it 
            _myProperty = "<deserialized value from db>";
        }
    
        private string _myProperty = string.Empty;
    
        [ConfigurationProperty("MyProperty", IsRequired = true)]
        public string MyProperty
        {
            get
            {
                if (_myProperty != null && _myProperty.Length > 0)
                    return _myProperty;
                else
                    return (string)this["MyProperty"];
            }
            set { this["MyProperty"] = value; }
        }
    }
