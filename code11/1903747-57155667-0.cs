    public void ConfigureServices(IServiceCollection services) {
        MySettings settings = configuration.GetSection("Section_Name_Here").Get<MySettings>();
        services.AddMvc();
        services.AddIdentityServer()
            .AddDeveloperSigningCredential(persistKey: false)
            .AddTestUsers(Config.GetUsers())
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients(settings)); //<--
    }
