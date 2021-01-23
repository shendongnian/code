    public interface IDatabaseConnection
    {
        void setQuery(string myQuery);
    }
    public class DBWrapper
    {
        private IDatabaseConnection Connection { get; set; } 
        public DBWrapper(string type)
        {
            if(type == "MySql")
                Connection = new DBMySQL();
            else if(type == "MsSql")
                Connection = new DBMSSQL();
        }
    }
    public class DBMySQL : IDatabaseConnection
    {
        ...
    }
    public class DBMSSQL : IDatabaseConnection
    {
        ...
    }
