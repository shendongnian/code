    public void ConfigureServices(IServiceCollection services)
            {
                services.AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            }
