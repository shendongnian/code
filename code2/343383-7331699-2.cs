        WebClient Client = new WebClient();
        public void TestStart()
        {
            //Handle the event for download complete
            Client.DownloadDataCompleted += Client_DownloadDataCompleted;
            //Start downloading file
            Client.DownloadDataAsync(new Uri("http://mywebsite.co.uk/myfile.txt"));
        }
        void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //Remove handler as no longer needed
            Client.DownloadDataCompleted -= Client_DownloadDataCompleted;
            //Get the data of the file
            byte[] Data = e.Result;
        }
        public void TestCancel()
        {
            Client.CancelAsync();
            Client.DownloadDataCompleted -= Client_DownloadDataCompleted;
        }
