    public class MysqlDbContext: DbContext
    {
         public MysqlDbContext() : base("MysqlDbContext")
         {
         }
         public string GetDatabaseName()
         {
             return MysqlDbContext.Database.Connection.Database;
         }
    }
