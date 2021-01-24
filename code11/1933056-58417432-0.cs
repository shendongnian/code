    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        ExecuteAzureDatabaseScripts(host);
        host.Run();
    }
    private static void ExecuteAzureDatabaseScripts(IWebHost host)
    {
        var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var hostingEnvironment = scope.ServiceProvider.GetService<IHostingEnvironment>();
            if (hostingEnvironment.IsDevelopment()) return;
            var scriptRunner = scope.ServiceProvider.GetService<SqlScriptRunner>();
            var storeContext = scope.ServiceProvider.GetService<IStoreDbContext>();
            scriptRunner.Context = storeContext;
            scriptRunner.Directory = @"SqlScripts\Azure";
            scriptRunner.ExecuteScripts();
        }
    }
