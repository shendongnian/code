    services.AddDbContext<MyDbContext>(builder => builder.UseSqlServer(connectionString));
    services.AddScoped<IMyDbContext>(serviceProvider => {
      //Get the configured context
      var dbContext = serviceProvider.GetRequiredService<MyDbContext>();  
      //And set the AAD token to its connection
      var connection = dbContext.Database.GetDbConnection() as System.Data.SqlClient.SqlConnection;
      if(connection == null) {/*either return dbContext or throw exception, depending on your requirements*/}
      connection.AccessToken = //code used to acquire an access token;
      return dbContext;
    });
