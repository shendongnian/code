    [HttpGet]
    [Authorize(AuthenticationSchemes = "AzureADBearer")]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
