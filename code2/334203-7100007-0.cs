    public void DownloadScript(Script script, string DownloadLocation) {
      ...
      WebClient Client = new WebClient();
      Client.DownloadFileCompleted += (sender, e) => Client_DownloadFileCompleted(
        sender, 
        e, 
        script);
    }
    public void Client_DownloadFileCompleted(
      object sender, 
      AsyncCompletedEventArgs e,
      Script script) {
      ...
    }
