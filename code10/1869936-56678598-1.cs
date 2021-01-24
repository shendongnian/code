services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services
            .AddEntityFrameworkSqlServer()
            .AddDbContext<EmployeeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EmployeeContext"));
            });
