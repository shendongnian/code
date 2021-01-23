    public class MyApplicationLogic
    {
        public const string UserSettingsFilename = "settings.xml";
        public string _DefaultSettingspath = 
            Assembly.GetEntryAssembly().Location + 
            "\\Settings\\" + UserSettingsFilename;
    
        public string _UserSettingsPath = 
            Assembly.GetEntryAssembly().Location + 
            "\\Settings\\UserSettings\\" + 
            UserSettingsFilename;
    
        public MyApplicationLogic()
        {
            // if default settings exist
            if (File.Exists(_UserSettingsPath))
                this.Settings = Settings.Read(_UserSettingsPath);
            else
                this.Settings = Settings.Read(_DefaultSettingspath);
        }
        public MySettings Settings { get; private set; }
    
        public void SaveUserSettings()
        {
            Settings.Save(_UserSettingsPath);
        }
    }
