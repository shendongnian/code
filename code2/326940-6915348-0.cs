      public static class FileUtility
      {
        private static void ProcessDir(string sourceDir, String userName, List<FileInfo> fileInfoList)
        {
            try
            {
                string userNameFirstLetter = userName.First().ToString();
                DirectoryInfo di = new DirectoryInfo(sourceDir);
                foreach (FileInfo fi in di.GetFiles())
                {
                    if ((fi.Extension == ".xls" || fi.Extension == ".xlsx" || fi.Extension == ".pdf")
                        && fi.Name.Contains(userName) && fi.Name.Contains("X")
                        && fi.Name.First().ToString().Equals(userNameFirstLetter)
                        && fi.Name.Split(Convert.ToChar("X"))[0].Equals(userName))
                     {
                        fileInfoList.Add(fi);
                     }
                }
                // Recurse into subdirectories of this directory.
                string[] subdirEntries = Directory.GetDirectories(sourceDir);
                foreach (string subdir in subdirEntries)
                {
                    // Do not iterate through reparse points
                    if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        ProcessDir(subdir, userName, fileInfoList);
                    }
                }
            }
            catch (DirectoryNotFoundException exp)
            {
                throw new DirectoryNotFoundException("Directory not found " + exp.Message);
            }
            catch (IOException exp)
            {
                throw new IOException("The Process cannot access the file because it is in use by another process " + exp.Message);
            }
        }
        public static List<FileInfo> GetFileInfoList(string sourceDir, string userName)
        {
            List<FileInfo> fileInfoList = new List<FileInfo>();
            ProcessDir(sourceDir, userName, fileInfoList);
            return fileInfoList;
        }
      }
