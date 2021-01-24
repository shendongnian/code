     WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(servicesCollection =>
             {
                 servicesCollection.AddSingleton<ITest, Test>(); 
                 // or get parent `IServiceCollection` and iterate over
             })
            .UseStartup<Startup>();
