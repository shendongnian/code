    var foo = Settings.Data['some']['settings'];
    // ..
    public static class Settings
    {
        static Settings()
        {
            string login = "Settings.ini";
            FileIniDataParser parser = new FileIniDataParser();
            _data = parser.LoadFile(login);
        }
        private static readonly IniData _data;
        public static IniData Data
        {
            get { return _data; }
        }
    }
