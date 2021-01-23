    sealed class MySettings : SettingsBase
    {
        [ApplicationScopedSetting()]
        [DefaultSettingValue("Default")]
        public string MySetting
        {
            get { return this["MySetting"].ToString(); }
            set { this["MySetting"] = value; }
        }
    }
