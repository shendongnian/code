            //Download files from FTP, return true or false if succed
        public static void DownloadFileFromFTP(string ip, string RemoteFilePath, string LocalFilePath, string username, string password)
        {
             ProgressBar progressBar;
             Progress<double> progress = new Progress<double>(x => {
               if (x > 0)
               {
                 progressBar.Report((double) x / 100);
               }   
             });
             FtpClient client = new FtpClient(ip);
             client.Credentials = new NetworkCredential(username, password);
             client.Connect();
             progressBar = new ProgressBar();
             client.DownloadFile(LocalFilePath, RemoteFilePath, FtpLocalExists.Overwrite, FluentFTP.FtpVerify.Retry, progress);
             progressBar.Dispose();
        }
