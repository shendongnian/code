            services
            .AddEntityFrameworkSqlServer()
            .AddDbContext<EmployeeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EmployeeContext"));
            });
