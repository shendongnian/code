            //Download files from FTP, return true or false if succed
        public static void DownloadFileFromFTP(string ip, string RemoteFilePath, string LocalFilePath, string username, string password)
        {
             FtpClient client = new FtpClient(ip);
             client.Credentials = new NetworkCredential(username, password);
             client.Connect();
             client.DownloadFile(LocalFilePath, RemoteFilePath, FtpLocalExists.Overwrite, FluentFTP.FtpVerify.Retry, progress);
        }
