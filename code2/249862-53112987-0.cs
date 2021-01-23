        static List<string> getFilesInDir(string dirPath)
        {
            List<string> retVal = new List<string>();
            try
            {
                retVal = IO.Directory.GetFiles(dirPath, "*.*", IO.SearchOption.TopDirectoryOnly).ToList();
                foreach (IO.DirectoryInfo d in new IO.DirectoryInfo(dirPath).GetDirectories("*", IO.SearchOption.TopDirectoryOnly))
                {
                    retVal.AddRange(getFilesInDir(d.FullName));
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(dirPath);
            }
            return retVal;
        }
