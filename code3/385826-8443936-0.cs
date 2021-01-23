    DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.RootDirectory.Exists)
                {
                    DirectoryInfo darr = new DirectoryInfo(drive.RootDirectory.FullName);
                    DirectoryInfo[] ddarr = darr.GetDirectories();
                    foreach (DirectoryInfo dddarr in ddarr)
                    {
                        if (dddarr.Exists)
                        {
                            try
                            {
                                Regex regx = new Regex(@"^(?!p_|t_)");
                                FileInfo[] f = dddarr.GetFiles().Where(path => regx.IsMatch(path));
                                List<FileInfo> myFiles = new List<FileInfo>();
                                foreach (FileInfo ff in f)
                                {
                                    if (ff.Extension == "*.png " || ff.Extension == "*.jpg")
                                    {
                                        myFiles.Add(ff);
                                        Console.WriteLine("File: {0}", ff.FullName);
                                        Console.WriteLine("FileType: {0}", ff.Extension);
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("File: {0}", "Denied");
                            }
                        }
                    }
                   
                }
            }
