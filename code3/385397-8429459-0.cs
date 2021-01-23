    WebClient webClient = new WebClient();
    webClient.DownloadStringCompleted += (s, e) =>
    {
        string xml = e.Result;
    };
    webClient.DownloadStringAsync(new Uri("http://..." + your params));
