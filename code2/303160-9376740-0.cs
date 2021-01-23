        [global::System.Configuration.UserScopedSettingAttribute()]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public List<ColumnSetting> Columns
        {
            get
            {
                return ((List<ColumnSetting>)this["Columns"]);
            }
            set
            {
                this["Columns"] = (List<ColumnSetting>)value;
            }
        }
