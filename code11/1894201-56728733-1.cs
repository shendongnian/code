    //...
    services.AddHttpClient<IDependency, Dependency>();
    services.AddScoped<Job1>();
    services.AddTransient<ISchedulerFactory, StdSchedulerFactory>();
    services.AddTransient<IJobFactory>(serviceProvider => new JobFactory(serviceProvider)); 
    services.AddHostedService<SchedulerService>();
    
    //...
    
