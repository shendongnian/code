    public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<sPPContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("changedButFrom.json")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }
