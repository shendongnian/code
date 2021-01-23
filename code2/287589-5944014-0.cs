    public class CoreConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("settings", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(CoreSettingCollection), AddItemName = "setting")]
        public CoreSettingCollection Settings
        {
            get
            {
                return (CoreSettingCollection)base["settings"];
            }
        }
    }
    public class CoreSetting : ConfigurationElement
    {
        public CoreSetting() { }
        public CoreSetting(string name, string value)
        {
            Name = name;
            Value = value;
        }
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("value", DefaultValue = null, IsRequired = true, IsKey = false)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
    public class CoreSettingCollection : ConfigurationElementCollection
    {
        public new string this[string name]
        {
            get { return BaseGet(name) == null ? string.Empty : ((CoreSetting)BaseGet(name)).Value; }
            set { Remove(name); Add(name, value); }
        }
        public void Add(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
                BaseAdd(new CoreSetting(name, value));
        }
        public void Remove(string name)
        {
            if (BaseGet(name) != null)
                BaseRemove(name);
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new CoreSetting();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CoreSetting)element).Name;
        }
    }
  
  
