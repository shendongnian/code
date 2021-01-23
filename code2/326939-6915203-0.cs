    public class FileUtility
        {
    
            public List<FileInfo> ProcessDir(string sourceDir, String userName)
            {
                List<FileInfo> fileInfoList = new List<FileInfo>();
                try
                {
                    string userNameFirstLetter = userName.First().ToString();
                    DirectoryInfo di = new DirectoryInfo(sourceDir);
    
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        if (fi.Extension == ".xls" || fi.Extension == ".xlsx" || fi.Extension == ".pdf")
                        {
                            if (fi.Name.Contains(userName))
                            {
                                if (fi.Name.Contains("X"))
                                {
                                    if(fi.Name.First().ToString().Equals(userNameFirstLetter))
                                    {
                                        if (fi.Name.Split(Convert.ToChar("X"))[0].Equals(userName))
                                        {
                                            fileInfoList.Add(fi);
                                        }
                                    }
                                }
                            }
                        }
                    }
    
                    // Recurse into subdirectories of this directory.
                    string[] subdirEntries = Directory.GetDirectories(sourceDir);
                    foreach (string subdir in subdirEntries)
                    {
                        // Do not iterate through reparse points
                        if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                        {
                            fileInfoList.AddRange(ProcessDir(subdir, userName));
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
                return fileInfoList;
            }
    
    }
