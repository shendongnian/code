    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "prop1", "value 1" },
            { "prop1", "value 2" },
        };
        var result = client.UploadValues("http://example.com/", values);
    }
