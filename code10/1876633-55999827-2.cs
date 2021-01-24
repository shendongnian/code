        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IClientErrorFactory, ProblemDetailsErrorFactory>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
