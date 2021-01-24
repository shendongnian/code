    public partial class DatabaseEntity : DbContext
    {
        public DatabaseEntity(string dbConn)
            : base(dbConn)
        {
        
        }
    
    }
    
    public static DbContext GetDBContext(int dbNumber)
    {
      //Get connection string which may be different for different database 
      string dbConnection = GetConnectionString(dbNumber);
    
      //
      var dbEntiry = new DatabaseEntity(dbConnection);
    
      return dbEntity;
    
    }
    
    
    public IQueryable<table> GetRecordsByNumBolla(string numBolla, DbContext dbContext)
    {
      var record = dbContext.Set<table1>().Where(x => x.number == numBolla);
      return record;
    }
