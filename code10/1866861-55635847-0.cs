    string GetCardMountPoint()
        {
            string[] listOfDirs = Directory.GetDirectories("/storage/");
            string path = null;
            foreach ( string dir in listOfDirs)
            {
                if(dir.Contains('-'))
                {
                    path = dir;
                }
            }
            return path;
