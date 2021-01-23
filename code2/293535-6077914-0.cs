    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "XMLData", format }
        };
        byte[] resultBuffer = client.UploadValues(url, values);
        string result = Encoding.UTF8.GetString(resultBuffer);
    }
