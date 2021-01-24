    public void ConfigureServices(IServiceCollection services) {
        //...
        InformationGetterOptions options = new InformationGetterOptions {
            ConnectionString = Configuration.GetSection("Model").GetSection("ConnectionString").Value;
            StoredProcedureName = "prInformationGetter";
        };
        services.AddSingleton(options);
        services.AddScoped<IInformationGetter, InformationGetter>();
        //...
    }
