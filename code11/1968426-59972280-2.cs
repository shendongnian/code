    // The class that represents database schema based on which databases 
    // are created. 
    public partial class DatabaseEntity : DbContext
    {
        public DatabaseEntity(string dbConn)
            : base(dbConn)
        {
        
        }
    }
    
    // This function creates instance of DbContext using connection string 
    // for that database represented by parameter dbNumber. 
    public DbContext GetDBContext(int dbNumber)
    {
      //Get connection string which may be different for different database 
      string dbConnection = GetConnectionString(dbNumber);
    
      //Create appropriate instance
      var dbContext= new DatabaseEntity(dbConnection);
    
      return dbContext;
    }
    
    // Function to get data
    public IQueryable<table> GetRecordsByNumBolla(string numBolla, DbContext dbContext)
    {
      var record = dbContext.Set<table1>().Where(x => x.number == numBolla);
      return record;
    }
    private string GetConnectionString(int dbNumber)
    {
        string connString = "";
        switch (dbNumber)
        {
            case 1:
                connString = @"server=localhost;database=DB1;uid=uid1;password=pwd1";
                break;
            case 2:
                connString = @"server=localhost;database=DB2;uid=uid2;password=pwd2";
                break;
            case 3:
                connString = @"server=localhost;database=DB3;uid=uid3;password=pwd3";
                break;
        }
        return connString;
    }
    
    //Code snippet to use these functions
    var dbContext = GetDBContext(1); //For 1st database
    
    var record = GetRecordsByNumBolla("XYZ",dbContext);
