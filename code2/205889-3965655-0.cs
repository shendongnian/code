        internal static string GetConfigSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName].ToString();
        }
        internal static bool GetConfigSettingBool(string settingName)
        {
            string setting = GetConfigSetting(settingName);
            if (string.IsNullOrEmpty(setting)) return false;
            bool value = false;
            if (bool.TryParse(setting, out value))
                return value;
            else
                return false;
        }
        internal static string[] GetConfigSettingsArray(string settingName)
        {
            return GetConfigSetting(settingName).Split(',');
        }
        internal static DateTime? GetConfigSettingDateTime(string settingName)
        {
            string setting = GetConfigSetting(settingName);
            DateTime retval;
            if (DateTime.TryParse(setting, out retval))
            {
                return retval;
            }
            else
            {
                return null;
            }
        }
        internal static void SetConfigSetting(string settingName, string value){
            ConfigurationManager.AppSettings[settingName] = value;
        }
