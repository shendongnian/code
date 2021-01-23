    public class ConfigeSystem: IInternalConfigSystem
    {
        public NameValueCollection Settings = new NameValueCollection();
        #region Implementation of IInternalConfigSystem
        public object GetSection(string configKey)
        {
            return Settings;
        }
        public void RefreshConfig(string sectionName)
        {
            //throw new NotImplementedException();
        }
        public bool SupportsUserConfig { get; private set; }
        #endregion
    }
