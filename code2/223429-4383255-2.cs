    public class MySection : ConfigurationSection
    {
        [ConfigurationProperty("MyElements", IsDefaultCollection = true)]
        public MyCollection Collection{get {return (MyCollection) this["MyElements"];}}
    }
    public class MyElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get {return (string) (base["name"]);}
            set {base["name"] = value;}
        }
        [ConfigurationProperty("value")]
        public string Value
        {
            get {return (string) (base["value"]);}
            set {base["value"] = value;}
        }
    }
