    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(c =>
        {
            c.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
        });
    }
