    public sealed class StringExtensionSettings
    {
        private StringExtensionSettings()
        {
        }
        private static StringExtensionSettings instance = null;
        public static StringExtensionSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StringExtensionSettings();
                }
                return instance;
            }
        }
        public bool DecryptString { get; set; } = true;
        public bool EncryptString { get; set; } = true;
        public bool RandomMix { get; set; } = true;
        public bool AddMidSubString { get; set; } = true;
    }
