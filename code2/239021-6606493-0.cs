    WebClient client = new WebClient();
    byte[] bytes = client.DownloadData(url);
    
    MemoryStream mem = new MemoryStream(bytes);
    StreamReader reader = new StreamReader(mem);
    string html = reader.ReadToEnd();
    html = HttpUtility.HtmlDecode(html);
