    var webUri = new Uri("www.website.com");
    var webClient = new WebClient();
    
    webClient.DownloadDataCompleted += DownloadDataCallback;
    webClient.DownloadStringAsync(webUri, null);
    
    private void DownloadDataCallback (Object sender, DownloadDataCompletedEventArgs e)
    {
         var webRequestResult = e.Result;
    }
