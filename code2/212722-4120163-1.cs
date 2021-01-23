        public static bool BooleanFeature
        {
            get { return Settings.GetSetting<bool>("BooleanFeature", true); }
            set { Settings.SaveSetting<bool>("BooleanFeature", value); }
        }
