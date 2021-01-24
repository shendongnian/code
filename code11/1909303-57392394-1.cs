    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(new CustomExceptionLogAttribute());
                });
        }
