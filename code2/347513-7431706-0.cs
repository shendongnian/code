    public class DataAccessDb1
    {
        public string ConnectionString {get;set;}
    
        public DataAccessDb1()
        {
            ConnectionString = "SetDbSpecificConnectionStringHere";
        }
    
        public void DataTable GetStuff()
        {
            return DataAccess.ExecuteSql(ConnectionString, "select * from stuff");
        }
    }
