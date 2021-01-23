    public class AssemblyElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _propAssembly;
        private static readonly ConfigurationPropertyCollection _properties;
        static AssemblyElement()
        {
            _propAssembly = new ConfigurationProperty("assembly", typeof(string), null, null, new StringValidator(1), ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propAssembly);
        }
        internal AssemblyElement() { }
        public AssemblyElement(string assemblyName)
        {
            this.Assembly = assemblyName;
        }
        [ConfigurationProperty("assembly", IsRequired = true, IsKey = true, DefaultValue = "")]
        [StringValidator(MinLength = 1)]
        public string Assembly
        {
            get { return (string)base[_propAssembly]; }
            set { base[_propAssembly] = value; }
        }
        internal AssemblyName AssemblyName
        {
            get { return new AssemblyName(this.Assembly); }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
