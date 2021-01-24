        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Uri url = new Uri("url");
            client.DownloadStringAsync(url);
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadStringCompleted += client_DownloadStringCompleted;
        }
        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            SetVisible(false);
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);
        }
        public void SetProgress(int val)
        {
            progressBar.Value = val;
        }
        public void SetVisible(bool val)
        {
            progressBar.Visible = val;
        }
