    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IMyUrlList, MyUrlList>();
     
        services.AddHttpClient("RemoteServer", client =>
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }).ConfigureHttpClient((serviceProvider, client) =>
        {
    		IMyUrlList myUrlList = serviceProvider.GetService<IMyUrlList>();
    		client.BaseAddress = myUrlList.NextUrl();
        });
     
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
