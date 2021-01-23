    WebClient webClient = new WebClient();
    webClient.DownloadProgressChanged += delegate(object sender, DownloadProgressChangedEventArgs e)
    {
        Console.WriteLine(e.BytesReceived);
    };
    webClient.DownloadDataAsync(new Uri(link));
