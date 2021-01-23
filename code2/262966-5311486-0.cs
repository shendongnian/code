    public class AppSettings : DictionaryConvertible
    {
        public AppSettings() { 
           // For unit testing
        }
        
        public AppSettings(ISettingsProvider settingsProvider) 
            : base(settingsProvider) {}        
        public string MyStringSetting { get; set; }
        public int MyIntSetting { get; set; }
        public bool MyBooleanSetting { get; set; }
    }
