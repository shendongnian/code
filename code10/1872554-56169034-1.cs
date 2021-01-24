    internal static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
       
        // Register the Swagger services
        services.AddSwaggerDocument(config =>
        {
            // Adds the "token" parameter in the request header, to authorize access to the APIs
            config.OperationProcessors.Add(new AddRequiredHeaderParameter());
            config.PostProcess = document =>
            {
                document.Info.Version = "v1";
                document.Info.Title = "Microsum api.mstiDFE";
                document.Info.Description = "API para geração de Documentos Fiscais Eletrônicos (DF-e) do projeto SPED";
                document.Info.TermsOfService = "None";
                document.Info.Contact = new NSwag.SwaggerContact
                {
                    Name = "Microsum Tecnologia da Informação Ltda",
                    Email = "suporte@microsum.com.br",
                    Url = "https://microsum.com.br"
                };
                document.Info.License = new NSwag.SwaggerLicense
                {
                    Name = "Use under LICX",
                    Url = "https://example.com/license"
                };
            };
        });            
    }
