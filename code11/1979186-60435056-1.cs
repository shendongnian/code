    using var serviceProvider = new ServiceCollection()
        .AddTransient<Program>()
        .AddTransient<Repository>()
        .AddTransient<MyContext>()
        .BuildServiceProvider();
    
    for (int i = 0; i < 3; ++i)
    {
        using var scope = serviceProvider.CreateScope();
        scope.ServiceProvider.GetService<Program>().Go();
    }
