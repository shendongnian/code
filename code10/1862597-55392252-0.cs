    /method?a=1&b=2&c=3
    
    [Route("method")]
    public string Get(string a= "", string b = "", string c = "")
    {
    return "ok";
    }
