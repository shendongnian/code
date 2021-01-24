     WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(servicesCollection =>
             {
                 servicesCollection.AddSingleton<ITest, Test>(); // or initialize somehow
             })
            .UseStartup<Startup>();
