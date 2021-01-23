    public static class Settings
    {
        private static string _root { get { return "core"; } }
        private static Configuration Load()
        {
            string filename = Path.Combine(Core.BaseDirectory, "core.config");
            var mapping = new ExeConfigurationFileMap {ExeConfigFilename = filename};
            var config = ConfigurationManager.OpenMappedExeConfiguration(mapping, ConfigurationUserLevel.None);
            var section = (CoreConfigurationSection)config.GetSection(_root);
            if (section == null)
            {
                Console.Write("Core: Building core.config...");
                section = new CoreConfigurationSection();
                config.Sections.Add(_root, section);
                Defaults(section);
                config.Save(ConfigurationSaveMode.Modified);
                
                Console.WriteLine("done");
            }
            return config;
        }
        
        private static void Defaults(CoreConfigurationSection section)
        {
            section.Settings["Production"] = "false";
            section.Settings["Debug"] = "false";
            section.Settings["EventBot"] = "true";
            section.Settings["WebAccounting"] = "true";
            section.Settings["AllowPlayers"] = "true";
        }
        #region Accessors
        public static string Get(string setting)
        {
            var config = Load();
            var section = (CoreConfigurationSection)config.GetSection(_root);
            return section.Settings[setting];
        }
        public static bool GetBoolean(string setting)
        {
            var config = Load();
            var section = (CoreConfigurationSection)config.GetSection(_root);
            return section.Settings[setting].ToLower() == "true";
        }
        
        public static void Set(string setting,string value)
        {
            var config = Load();
            var section = (CoreConfigurationSection)config.GetSection(_root);
            if (value == null)
                section.Settings.Remove(setting);
            section.Settings[setting] = value;
            config.Save(ConfigurationSaveMode.Modified);
        }
        public static void SetBoolean(string setting, bool value)
        {
            var config = Load();
            var section = (CoreConfigurationSection)config.GetSection(_root);
            section.Settings[setting] = value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }
        
        #endregion
        #region Named settings
        public static bool Production
        {
            get { return GetBoolean("Production"); }
            set { SetBoolean("Production", value); }
        }
        public static bool Debug
        {
            get { return GetBoolean("Debug"); }
            set { SetBoolean("Debug", value); }
        }
        public static bool EventBot
        {
            get { return GetBoolean("EventBot"); }
            set { SetBoolean("EventBot", value); }
        }
        public static bool WebAccounting
        {
            get { return GetBoolean("WebAccounting"); }
            set { SetBoolean("WebAccounting", value); }
        }
        public static bool AllowPlayers
        {
            get { return GetBoolean("AllowPlayers"); }
            set { SetBoolean("AllowPlayers", value); }
        }
        #endregion
    }
