    public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json") //<-- or whichever file has that information
            .Build();
        string path = configuration.GetValue<string>("MyAWSSectionName:SystemsManager");
        //Or a strongly typed model with aws options
        return WebHost.CreateDefaultBuilder(args)
                  .ConfigureAppConfiguration(builder =>
                  {
                      builder.AddSystemsManager(path);
                  })
                  .UseStartup<Startup>();
    }
        
