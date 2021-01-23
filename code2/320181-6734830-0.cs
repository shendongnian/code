    public abstract class SettingsHelperBase { public object GetSettingValue(string settingName); }
    // Assembly1
    public class SettingsHelper : SettingsHelperBase { }
    // Assembly2
    public class SettingsHelper : SettingsHelperBase { }
    public class SettingsHelper : SettingsHelperBase
    {
        private List<SettingsHelperBase> _backends = new List<SettingsHelperBase>();
        public readonly PropertiesImpl Properties;
        public class PropertiesImpl
        {
            private SettingsHelper _settingsHelper;
            public string Name
            {
                get
                {
                    return (string)_settingsHelper.GetSettingValue("Name");
                }
            }
            internal PropertiesImpl(SettingsHelper helper)
            {
                _settingsHelper = helper;
            }
        }
        public SettingsHelper()
        {
            _backends.Add(asm1::MyNs.SettingsHelper);
            _backends.Add(asm2::MyNs.SettingsHelper);
            Properties = new PropertiesImpl(this);
        }
        protected override object GetSettingValue(string settingName)
        {
            foreach (var item in _backends)
            {
                var val = item.GetSettingValue(settingName);
                if (val != null)
                    return val;
            }
            return null;
        }
    }
