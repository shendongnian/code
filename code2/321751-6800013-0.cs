    private void btnDownload_Click(object sender, EventArgs e)
    {
      string filepath = textBox1.Text;
      WebClient webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
      webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
      webClient.DownloadFileAsync(new Uri("http://mysite.com/myfile.txt"), filepath);
    }
    
    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      progressBar.Value = e.ProgressPercentage;
    }
    
    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
      MessageBox.Show("Download completed!");
    }
