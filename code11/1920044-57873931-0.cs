    //...
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(SKCASGlobals.SK_ConnectionString));
    
    services.AddDbContext<StarKeepDbContext>((serviceProvider, options) => {
        var contextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        var appData = serviceProvider.GetRequiredService<AppDbContext>();
        
        var userId = //...use the accessor to identify currently authenticated user
        
        //...and then extract the connection string from app data        
        var user = appData.Users.Where(u => user.SomeIdentifies == userId).FirstOrDefault();
        
        //Fail early
        if(user == null) throw new InvalidOperation("Invalid user");
        
        connectionString = user.Company.ConnectionString; //Assuming navigation property
        
        //set connection string
        options.UseSqlServer(connectionString)
    });
    services.AddHttpContextAccessor();
    //...
    
