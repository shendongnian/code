        public static bool IsFileInUse(string pathToFile)
        {
            if (!System.IO.File.Exists(pathToFile))
            {
                // File doesn't exist, so we know it's not in use.
                return false;
            }
            bool inUse = false;
            System.IO.FileStream fs;
            try
            {
                fs = System.IO.File.Open(pathToFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
                fs.Close();
            }
            catch (System.IO.IOException ex)
            {
                string exMess = ex.Message;
                inUse = true;
            }
            return inUse;
        }
