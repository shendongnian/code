    public static  class WebConfiguration<T>
    {
        public static dynamic Get {
            get { return _settings; }
        }
        static readonly SettingsProxy _settings = new SettingsProxy ();
        class SettingsProxy : DynamicObject
        {
            public override bool TryGetMember (GetMemberBinder binder, out object result)
            {
                var setting = ConfigurationManager.AppSettings [binder.Name];
                if (setting != null) {
                    result = Convert.ChangeType (setting, typeof(T));
                    return true;
                }
                result = null;
                return false;
            }
        }
    }
