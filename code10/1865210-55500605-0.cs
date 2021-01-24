    services.AddDbContext<MyDBContext>(options => {
                SqlConnection conn = new SqlConnection(Configuration["ConnectionString"]);
                conn.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/")
                            .Result;
                options.UseSqlServer(conn);
    });
