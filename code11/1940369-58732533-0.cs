        public void ConfigureServices(IServiceCollection services)
        {
        // Add framework services.
        services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }
