        struct FtpSetting
        {
            public string Server { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
         
        }
        FtpSetting _inputParameter;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileName = "";
            string fullName = "";
            string dir = "C:\\Users\\bluevels\\Desktop\\ww\\";
            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                string FileName = "C:\\Users\\bluevels\\Desktop\\ww\\" + Path.GetFileName(file);
                FileInfo fi = new FileInfo(FileName);
                fileName = fi.Name;
                fullName = fi.FullName;
                string userName = ((FtpSetting)e.Argument).Username;
                string password = ((FtpSetting)e.Argument).Password;
                string server = ((FtpSetting)e.Argument).Server;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", server, fileName)));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(userName, password);
                Stream ftpStream = request.GetRequestStream();
                FileStream fs = File.OpenRead(fullName);
                byte[] buffer = new byte[1024];
                double total = (double)fs.Length;
                int byteRead = 0;
                double read = 0;
                do
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        //Upload file & update process bar
                        byteRead = fs.Read(buffer, 0, 1024);
                        ftpStream.Write(buffer, 0, byteRead);
                        read += (double)byteRead;
                        double percentage = read / total * 100;
                        backgroundWorker.ReportProgress((int)percentage);
                    }
                }
                while (byteRead != 0);
                fs.Close();
                ftpStream.Close();
            }
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = $"Uploaded {e.ProgressPercentage} %";
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Upload complete !";
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
                    _inputParameter.Username = txtUserName.Text;
                    _inputParameter.Password = txtPassword.Text;
                    _inputParameter.Server = txtServer.Text;
                    backgroundWorker.RunWorkerAsync(_inputParameter);
                
            
        }
