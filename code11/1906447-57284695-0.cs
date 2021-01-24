    services.AddDbContext<AlpinehutsDbContext>(options =>
    {
        var dbConnection = new SqlConnection(Configuration["DatabaseConnectionString"])
        {
            AccessToken = new AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/").Result
        };
        options.UseSqlServer(dbConnection);
    });
