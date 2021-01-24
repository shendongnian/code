    public static void Main(string[] args)
    {
        // create and build the host to make the DI container available
        var host = CreateHostBuilder(args).Build();
        // create a DI service scope in which the initialization can be done
        using (var scope = host.Services.CreateScope())
        {
            // retrieve service and initialize whatever
            var token = scope.ServiceProvider.GetService<ValidationToken>();
            token.Initialize();
        }
        // start the host which spins up e.g. the ASP.NET Core web application
        host.Run();
    }
