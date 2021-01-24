        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadFileAsync(new Uri("https://www.example.com/filepath"), @"C:\Users\currentuser\Desktop\Test.zip");
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            TBStatus.Text = e.ProgressPercentage + "% " + e.BytesReceived + " of " + e.TotalBytesToReceive + " received.";
        }
        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed");
        }
