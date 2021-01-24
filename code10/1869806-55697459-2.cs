        public class ConfigureSwaggerApiVersioning : IConfigureOptions<SwaggerGenOptions>
        {
            private readonly IApiVersionDescriptionProvider _provider;
        
            public ConfigureSwaggerApiVersioning(IApiVersionDescriptionProvider provider)
            {
                _provider = provider;
            }
            private static Info CreateInfoForApiVersion(ApiVersionDescription description)
            {
                return new Info()
                {
                    //Title = "...",
                    Version = description.ApiVersion.ToString(),
                    //Description = "...",
                    Contact = new Contact() { Name = "...", Email = "..." },
                    //TermsOfService = "..."
                    //License = new License() { Name = "...", Url = "..." }
                };
            }
    
            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
            }
        }
