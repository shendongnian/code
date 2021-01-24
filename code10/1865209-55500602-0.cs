    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<ISqlConnectionProvider, SqlConnectionProvider>();
        services.AddDbContext<TestDbContext>((provider, options) =>
        {
            var connectionTokenProvider = provider.GetService<ITokenProvider>();
            var sqlConnectionProvider = provider.GetService<ISqlConnectionProvider>();
            var accessToken = connectionTokenProvider.GetAsync().Result; // Yes, I consider this to be less than elegant, but marking this delegate as async & awaiting would result in a race condition.
            var sqlConnection = sqlConnectionProvider.CreateSqlConnection(accessToken);
            options.UseSqlServer(sqlConnection);
        });
    }
