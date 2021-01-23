    public class Settings
    {
        const string SettingPath = "Settings";
        public static Settings Instance
        {
            get
            {
                var result = HttpContext.Application[SettingPath] as Settings;
                if (result == null)
                {
                    var result = new Settings();
                    HttpContext.Current.Application[SettingPath] = result;
                }
                return result;
            }
        }
        private Settings()
        {
            // Load properies here
        }
        // Properties Here
    }
