    namespace my_project
    {
        public class settings
        {
            public IniData Ini
            {
                get
                {
                    string login = "Settings.ini";
                    FileIniDataParser parser = new FileIniDataParser();
    
                    // Parse the ini file with the settings
                    IniData settings = parser.LoadFile(login);
                    //*strptr = settings;
                    return settings;
                }
            }
        }
    }
