    public MyConstructor(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task OnGet()
    {
        ....
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);
        ...
    }
