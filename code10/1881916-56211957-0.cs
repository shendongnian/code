    async Task Test()
    {
        var httpClient = new HttpClient(new TestHttpMessageHandler());
    
        var ticks = Environment.TickCount;
    
        await Task.WhenAll(Enumerable.Range(0, 10).Select(_ => httpClient.GetAsync("https://stackoverflow.com/")));
    
        Console.WriteLine($"{Environment.TickCount - ticks}ms");
    }
    
    class TestHttpMessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
    
            return new HttpResponseMessage();
        }
    }
