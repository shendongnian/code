     using System.Net.FtpClient;
     static void DeleteFtpDirectoryAndContent(string host, string path, NetworkCredential credentials, string dontDeleteFileUrl)
        {
            using (FtpClient conn = new FtpClient())
            {
                conn.Host = host;
                conn.Credentials = credentials;
                foreach (FtpListItem item in conn.GetListing(path, FtpListOption.AllFiles | FtpListOption.ForceList))
                {
                    switch (item.Type)
                    {
                        case FtpFileSystemObjectType.Directory:
                            conn.DeleteDirectory(item.FullName, true, FtpListOption.AllFiles | FtpListOption.ForceList);
                            break;
                        case FtpFileSystemObjectType.File:
                            if (!dontDeleteFileUrl.EndsWith(item.FullName, StringComparison.InvariantCultureIgnoreCase))
                                conn.DeleteFile(item.FullName);
                            break;
                    }
                }
            }
        }
