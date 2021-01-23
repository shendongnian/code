    WebClient MyWebClient = new WebClient();
    foreach (var url in urls_to_download)
    {
        MyWebClient.DownloadString(url);
    }
    ---------------
    foreach (var url in urls_to_download)
    {
        WebClient MyWebClient = new WebClient();
        MyWebClient.DownloadString(url);
    }
