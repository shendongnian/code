    public class ConfigurationKeyAttribute : Attribute
    {
        private readonly string _key;
        private readonly string _machineName;
    
        public ConfigurationKeyAttribute(string key, string machineName)
        {
            _key = key;
            _machineName = machineName;
        }
    
        protected ConfigurationKeyAttribute(string key) : this(key, null)
        {
        }
    
        public string Key { get { return _key; } }
        public virtual string MachineName { get { return _machineName; } }
    }
    
    public class LocalMachineConfigurationKeyAttribute : ConfigurationKeyAttribute
    {
        public LocalMachineConfigurationKeyAttribute(string key) : base(key)
        {
        }
    
        public override string MachineName { get { return Environment.MachineName; } }
    }
