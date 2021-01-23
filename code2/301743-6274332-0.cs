    public class Settings
    {
        private static Settings systemSettings;
        public static Settings SystemSettings 
        {
            get
            {
                if (systemSettings == null)
                    systemSettings = new Settings();
                return systemSettings;
            }
        }
        public int SettingValue1{ get; set; }
        private Settings()
        {
            SettingValue1 = 1;//from registery or somewhere
        }
    
    
    }
