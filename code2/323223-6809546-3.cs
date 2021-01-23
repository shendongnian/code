    using (var client = new WebClientEx())
    {
        client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:5.0) Gecko/20100101 Firefox/5.0";
        client.Headers[HttpRequestHeader.AcceptLanguage] = "en-us,en;q=0.5";
        var values = new NameValueCollection
        {
            { "foo", "some value" },
            { "bar", "some & other + value =" },
        };
        byte[] buffer = client.UploadValues("http://www.example.com", values);
        string result = Encoding.UTF8.GetString(buffer);
    }
