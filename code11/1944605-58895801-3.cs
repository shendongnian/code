        public void ConfigureServices(IServiceCollection services)
        {
            ......
            services.AddHttpContextAccessor();
            services.Configure<SqlSettings>(Configuration.GetSection("sql"));
            services.AddEntityFrameworkSqlServer().AddDbContext<CustomContext>();
        }
