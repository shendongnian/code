    using(var connection = new SqliteConnection("DataSource=:memory:"))
    {
    	connection.Open();
    	var options = new DbContextOptionsBuilder<DataContext>()
                       .UseSqlite(connection)                  
                       .Options;
    
    	var dbContext = new DataContext(options);
    	dbContext.Database.EnsureCreated();
        //You testing logic goes here.
    }
