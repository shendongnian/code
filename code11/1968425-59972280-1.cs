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
    public static DbContext GetDBContext(int dbNumber)
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
