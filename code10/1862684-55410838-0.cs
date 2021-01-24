    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options => {
            options.OutputFormatters.Insert(0, new XmlDataContractSerializerOutputFormatter());
        }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
