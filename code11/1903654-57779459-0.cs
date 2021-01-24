    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(confBuilder =>
                {
                    confBuilder.SetBasePath(Directory.GetCurrentDirectory());
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "tenant-configs");
                    confBuilder.AddKeyPerFile(path, true);
                })
                .UseStartup<Startup>();
