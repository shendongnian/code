            ConfigeSystem configSystem = new ConfigeSystem();
            configSystem.Settings.Add("s1","S");
            Type type = typeof(ConfigurationManager);
            FieldInfo info = type.GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, configSystem);
            bool res = ConfigurationManager.AppSettings["s1"] == "S"; // return true
