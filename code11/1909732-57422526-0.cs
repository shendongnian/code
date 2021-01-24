     public void ConfigureServices(IServiceCollection services)
     {
                        
            services.AddEntityFrameworkOracle()
                .AddDbContext<OracleDbContext>(builder => builder.UseOracle(Configuration["Data:OracleDbContext"]),ServiceLifetime.Scoped)
                .AddDbContext<AppsDbContext>(option => option.UseOracle(Configuration["Data:AppsDbConnection:ConnectionString"]), ServiceLifetime.Scoped);
