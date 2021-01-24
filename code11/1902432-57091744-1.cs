    public TestADLS_Operations()
    {
        //setup TestServer
        IWebHostBuilder hostBuilder = new WebHostBuilder()
            .Configure(app => app.Run(
            async context =>
        {
            // set your response headers via the context.Response.Headers property
            // set your response content like this:
            byte[] content = Encoding.Unicode.GetBytes("myResponseContent");
            await context.Response.Body.WriteAsync(content);
        }));
        var testServer = new TestServer(hostBuilder)
        var factory = new InMemoryHttpClientFactory(testServer);
        _iADLS_Operations = new ADLS_Operations(factory);
        [...]
    }
