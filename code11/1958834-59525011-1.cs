    public void ConfigureServices(IServiceCollection services)
    {
        //do your stuff..
        services.AddControllers().AddNewtonsoftJson();
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        //do your stuff..
    }
