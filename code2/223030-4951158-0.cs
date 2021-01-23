    public class AzureConfig:StandaloneConfig
    {
        protected override string GetAppSetting(string name)
        {
            return RoleEnvironment.GetConfigurationSettingValue(name);
        }
        protected override string GetConnectionString(string name)
        {
            return RoleEnvironment.GetConfigurationSettingValue(name);
        }
    }
    public class StandaloneConfig
    {
        public IndexedSetting AppSettings { get; private set; }
        public IndexedSetting ConnectionStrings { get; private set; }
        public StandaloneConfig()
        {
            AppSettings = new IndexedSetting(GetAppSetting);
            ConnectionStrings = new IndexedSetting(GetConnectionString);
        }
        protected virtual String GetAppSetting(String name)
        {
            return ConfigurationManager.AppSettings[name];
        }
        protected virtual String GetConnectionString(String name)
        {
            var cs = ConfigurationManager.ConnectionStrings[name];
            if (cs != null)
                return cs.ConnectionString;
            else
                return null;
        }
        public class IndexedSetting
        {
            Func<String, String> _getParameter;
            public IndexedSetting(Func<String,String> getParameter)
            {
                _getParameter = getParameter;
            }
            public String this[String name]
            {
                get { return _getParameter(name); }
            }
        }
