    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.UserAgent] = "Hacker";
        client.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        client.Headers[HttpRequestHeader.Referer] = "http://yougothacked.com";
        client.UploadValues("http://87.255.55.218/register", new NameValueCollection
        {
            { "username", "foo" },
            { "someOtherParam", "value" }
        });
    }
