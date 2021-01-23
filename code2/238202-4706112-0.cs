    public class FrameworkSettings
    {
        public static int ListenPort { get; set; }
        public static int NumberOfOutgoingLines { get; set; }
        public static void Load(FrameSettings settings)
        {
            ListenPort = settings.ListenPort;
            NumberOfOutgoingLines = settings.NumberOfOutgoingLines;
        }
    }
    public class FrameSettings
    {
        [YAXErrorIfMissed(YAXExceptionTypes.Warning, DefaultValue = 5060)]
        public int ListenPort { get; set; }
        [YAXErrorIfMissed(YAXExceptionTypes.Warning, DefaultValue = 5)]
        public int NumberOfOutgoingLines { get; set; }
        public void Save()
        {
            ListenPort = FrameworkSettings.ListenPort;
            NumberOfOutgoingLines = FrameworkSettings.NumberOfOutgoingLines;
        }
    }
    public class SettingsManager
    {
        YAXSerializer _mSerializer;
        FrameSettings _mFrameSettings;
        public SettingsManager()
        {
            _mFrameSettings = new FrameSettings();
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
        }
        public void LoadSettings()
        {
            _mSerializer = new YAXSerializer(typeof(FrameSettings), 
                                            YAXExceptionHandlingPolicies.ThrowErrorsOnly, 
                                            YAXExceptionTypes.Warning);
            _mFrameSettings = (FrameSettings)_mSerializer.DeserializeFromFile("data\\settings.xml");
            FrameworkSettings.Load(_mFrameSettings);
        }
        public void SaveSettings()
        {
            _mFrameSettings.Save();
            _mSerializer.SerializeToFile(_mFrameSettings, "data\\settings.xml");
        }
