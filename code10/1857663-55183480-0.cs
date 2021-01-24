    private static void GetFiles()
        {
            using (FtpClient conn = new FtpClient())
            {
                string ftpPath = "ftp://myftp/";
                
                string downloadFileName = @"C:\temp\FTPTest\";
                
                downloadFileName +=  "\\";
                conn.Host = ftpPath;
                //conn.Credentials = new NetworkCredential("ftptest", "ftptest");
                conn.Connect();
                //Get all directories
                foreach (FtpListItem item in conn.GetListing(conn.GetWorkingDirectory(),
                    FtpListOption.Modify | FtpListOption.Recursive))
                {
                    // if this is a file
                    if (item.Type == FtpFileSystemObjectType.File)
                    {
                        string localFilePath = downloadFileName + item.FullName;
                        //Only newly created files will be downloaded.
                        if (!File.Exists(localFilePath))
                        {
                            conn.DownloadFile(localFilePath, item.FullName);
                            //Do any action here.
                            Console.WriteLine(item.FullName);
                        }
                    }
                }
            }
        }
