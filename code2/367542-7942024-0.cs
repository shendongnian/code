    public interface IDBAccess
    {
         public void setQuery(...);
    }
    
    public class DBMySQL : IDBAccess
    {
        public string dbinfo;
        string query;
    
        public DBMySQL(...)
        {
            dbinfo = ...;
    
        }
    
        public void setQuery(...)
        {
            query = myquery;
        }
    }
    
    public class DBMSSQL : IDBAccess
    {
        public string dbinfo;
        string query;
    
        public DBMSSQL(...)
        {
            dbinfo = ...;
    
        }
    
        public void setQuery(...)
        {
            query = myquery;
        }
    }
