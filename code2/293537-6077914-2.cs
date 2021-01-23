    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.ContentType] = "text/xml";
        var data = Encoding.UTF8.GetBytes(format);
        byte[] resultBuffer = client.UploadData(url, data);
        string result = Encoding.UTF8.GetString(resultBuffer);
    }
