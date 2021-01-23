    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "username", USERNAME }
        };
        var result = client.UploadValues("http://foo.com", values);
    }
