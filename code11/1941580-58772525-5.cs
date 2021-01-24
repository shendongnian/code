    WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(servicesCollection =>
             {
                 var mainServiceCollection = ...;
                 servicesCollection.AddRange(mainServiceCollection);
             })
            .UseStartup<Startup>();
