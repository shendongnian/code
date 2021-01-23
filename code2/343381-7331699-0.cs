        WebClient Client = new WebClient();
        public void TestStart()
        {
            Client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(Client_DownloadDataCompleted);
            Client.DownloadDataAsync(new Uri("http://mywebsite.co.uk/myfile.txt"));
        }
        void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Client.DownloadDataCompleted -= Client_DownloadDataCompleted;
            byte[] Data = e.Result;
        }
        public void TestCancel()
        {
            Client.CancelAsync();
            Client.DownloadDataCompleted -= Client_DownloadDataCompleted;
        }
