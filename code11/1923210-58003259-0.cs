 public void ConfigureServices(IServiceCollection services)
        {
            _ = services
               .AddCorrelationIdFluent()
               .AddCustomCaching()
               .AddCustomOptions(this.configuration)
               .AddCustomRouting()
               .AddCustomResponseCompression()
               .AddCustomStrictTransportSecurity()
               .AddCustomHealthChecks()
               .AddHttpContextAccessor()
               .AddMvcCore()
                   .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                   .AddAuthorization()
                   .AddCustomJsonOptions(this.hostingEnvironment)
                   .AddCustomCors()
                   .AddCustomMvcOptions(this.hostingEnvironment);
            _ = services
               .AddCustomGraphQL(this.hostingEnvironment)
               .AddCustomGraphQLAuthorization()
               .AddProjectRepositories()
               .AddProjectSchemas();
         
            _ = services.AddMvc()
                    .AddNewtonsoftJson();
        }
I was told by a co-worker to take out the `.BuildServiceProvider` so that is why it is no longer there If this is wrong or anyone know a better way let us know :)
