    public class WatchConfig: ApplicationSettingsBase
    {
        static WatchConfig_defaultInstance = (WatchConfig)Synchronized(new WatchConfig());
        public static WatchConfig Default { get => _defaultInstance; }
        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Save();
            base.OnPropertyChanged(sender, e);
        }
        [UserScopedSetting]
        [global::System.Configuration.DefaultSettingValueAttribute(
        @"<?xml    version=""1.0"" encoding=""utf-16""?>
        <ArrayOfString>
          <string>C:\temp</string>
         <string>..\otherdir</string>
         </ArrayOfString>")]
        public StringCollection Directories
        {
            get { return (StringCollection)this[nameof(Directories)]; }
            set { this[nameof(Directories)] = value; }
        }
    }
