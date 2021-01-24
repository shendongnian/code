    public static async Task Main(string[] args)
    {
        var webHost = CreateWebHostBuilder(args)
            .Build();
        await webHost.SomeExtensionAsync();
        webHost.Run();
    }
