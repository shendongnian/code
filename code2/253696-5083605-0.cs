    Private void btnDownload_Click(object sender, EventArgs e)
    {
      WebClient webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
      webClient.DownloadFileAsync(new Uri("http://mysite.com/myfile.txt"), @"c:\myfile.txt");
    }
    
    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
      MessageBox.Show("Download completed!");
    }
