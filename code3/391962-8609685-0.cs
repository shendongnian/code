        private void btnStartDownload_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(@"http://www.trendmicro.com/ftp/products/wfbs/WFBS70_EN_GM_B1343.exe"), @"C:\temp\WFBS7.exe");
            btnStartDownload.Text = "Download In Process";
            btnStartDownload.Enabled = false;
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed");
            btnStartDownload.Text = "Start Download";
            btnStartDownload.Enabled = true;
        }
