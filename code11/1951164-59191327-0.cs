    [HttpGet]
    [HttpPost]
    public ContentResult GetXml(string value)
    {
        var xml = $"<result><value>{value}</value></result>";
        return new ContentResult
        {
            Content = xml,
            ContentType = "application/xml",
            StatusCode = 200
        };
    }
