    Task<string> DownloadUrlAsync(string url,HttpClient client)
    {
        return client.GetStringAsync(url);
    }
    void ParseResponse(string content)
    {
        var object=JObject.Parse();
        DoSomethingWith(object);
    }
    
