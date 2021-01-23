    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "key1", "value1" },
            { "key2", Convert.ToBase64String(File.ReadAllBytes(test)) },
        };
        byte[] result = client.UploadValues("http://example.com/test.aspx", values);
    }
