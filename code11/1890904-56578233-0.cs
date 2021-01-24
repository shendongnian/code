    services.AddScoped<MainContext>(serviceProvider => {
          var dbContext = serviceProvider.GetRequiredService<MainContext>();  
          var connection = dbContext.Database.GetDbConnection() as SqlConnection;
          if(connection == null) {
              return dbContext;
          }
          connection.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
          return dbContext;
    });
