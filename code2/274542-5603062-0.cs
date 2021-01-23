    using(var webClient = new WebClient { Encoding = Encoding.UTF8 })
    {
        string json = webClient.DownloadString(someUri);
        ...
    }
