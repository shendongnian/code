        public static bool ParentDirectoryExists(string dir)
        {
            DirectoryInfo dirInfo = Directory.GetParent(dir);
            if ((dirInfo != null) && dirInfo.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
