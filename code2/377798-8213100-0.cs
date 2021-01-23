    using (var client = new WebClient())
    {
        client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
        string resultData = client.UploadString(url, data);
    }
