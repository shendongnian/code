    services.AddScoped<YourDbContext>(svc =>
         {
             var connString = ... logic to get the conn string with the right password from HashiCorp vault;
             var dbContextOptions = new DbContextOptionsBuilder<YourDbContext>();
             dbContextOptions.UseSqlServer(connString); //Or w/e ef provider for db you use
             return new YourDbContext(dbContextOptions.Options);
         });
