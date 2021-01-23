    public class DisplayNameSettingsKeyAttribute : DisplayNameAttribute
    {
        private readonly string _settingsKey;
    
        public DisplayNameSettingsKeyAttribute(string settingsKey)
        {
            _settingsKey = settingsKey;
        }
    
        public string SettingsKey
        {
            get { return _settingsKey; }
        }
    
        public override string DisplayName
        {
            get { return (string)Properties.Settings.Default[_settingsKey]; }
        }
    }
