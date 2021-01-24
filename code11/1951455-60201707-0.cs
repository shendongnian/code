        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpContextAccessor();
            services.AddMvc(setup => { }).AddFluentValidation();
            services.AddTransient<IValidator<MyModel>, MyModelValidator>();
        }
