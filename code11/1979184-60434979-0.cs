    static void Main() {
        serviceProvider = new ServiceCollection()
            .AddTransient<Program>()
            .AddTransient<Repository>()
            .AddTransient<MyContext>()
            .BuildServiceProvider();
        serviceProvider.GetService<Program>().Go();
    }
    private static IServiceProvider serviceProvider;
