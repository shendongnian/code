     WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(servicesCollection =>
             {
                 servicesCollection.AddSingleton<ITest, Test>(); // or call your extension method
             })
            .UseStartup<Startup>();
