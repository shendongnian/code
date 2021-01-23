    string html = string.Empty;
    using (WebClient client = new WebClient())
    {
        client.Headers.Add("user-agent",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        using (Stream data = client.OpenRead("http://someurl.com"))
        using (StreamReader reader = new StreamReader(data))
        {
            html = reader.ReadToEnd();
        }
    }
