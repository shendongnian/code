     you can use following instead...
    
    WebClient client = new WebClient();
    client.Encoding = System.Text.Encoding.UTF8;// GetEncoding(1252);
    UrlContent =client.DownloadString(url);
