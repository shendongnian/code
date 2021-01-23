        public IniData ini
        {
            get
            { 
                string login = "Settings.ini";
                FileIniDataParser parser = new FileIniDataParser();
                // Parse the ini file with the settings
                IniData settings = parser.LoadFile(login);
                return settings;
            }
        }
