    private readonly IHttpClientFactory _httpClientFactory;
    public ValuesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var client = _httpClientFactory.CreateClient();
        var result = await client.GetStringAsync("www.bWebSiteUrl.com/api/???");
        return Ok(result);
    }
}
