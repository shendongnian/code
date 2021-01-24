    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
    #if useAutofac
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    #endif
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
            .ConfigureServices(services => {
                services.AddHostedService<HostedService>();
            })
            .Build();
        await host.RunAsync();
    }
