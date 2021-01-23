    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0) Gecko/20100101 Firefox/4.0";
        var values = new NameValueCollection
        {
            { "param1", "value1" },
            { "param2", "value2" },
        };
        byte[] result = client.UploadValues(url, values);
    }
