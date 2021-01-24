    public static async Task Main(string[] args)
    {
        var webHost = CreateWebHostBuilder(args).Build();
        await webHost.Services.GetRequiredService<IService>().InitAsync();
        webHost.Run();
        // await webHost.RunAsync();
    }
