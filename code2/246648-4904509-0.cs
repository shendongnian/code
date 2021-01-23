    public abstract class MyBaseClass
    {
        public dynamic Settings
        {
            get { return _settings; }
        }
    
        private SettingsProxy _settings = new SettingsProxy();
    
        private class SettingsProxy : DynamicObject
        {
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var setting = ConfigurationManager.AppSettings[binder.Name];
                if(setting != null)
                {
                    result = setting.ToString();
                    return true;
                }
                result = null;
                return false;
            }
        }
    }
