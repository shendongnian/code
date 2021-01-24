    [HttpGet("qqq", Name = "xxx")]
    public string yyy()
    {
       return "This is the action yyy";
    }
    [HttpGet("test")]
    public string test()
    {
        var url = Url.Link("xxx", null);  //Mine is https://localhost:44384/api/qqq
        return $"The url of Route Name xxx is {url}";
    }
