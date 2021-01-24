    public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
            var sp = services.BuildServiceProvider();
            var employeeProvider = sp.GetService<IEmployeeProvider>();
            string[] values = employeeProvider.GetAuthorizedEmployeeIds();
            services.AddAuthorization(options =>
            {
                
                options.AddPolicy("Founders", policy =>
                          policy.RequireClaim("EmployeeNumber", employeeProvider.GetAuthorizedEmployeeIds()));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
