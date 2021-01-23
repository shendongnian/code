    public class Settings
    {
        private static IniData ini;
        public static IniData Ini
        {
            get
            {
                if (ini == null)
                {
                    string login = "Settings.ini";
                    FileIniDataParser parser = new FileIniDataParser();
                    ini = parser.LoadFile(login);
                }
                return ini;
            }
        }
    }
