         [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("3")]
        public string Setting1
        {
            get
            {
                return (string)this["Setting1"];
            }
        }
