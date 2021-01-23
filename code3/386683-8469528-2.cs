    public interface IDatabase {
       void Connect(string ...);
       string Query(string ...);
    }
    
    public class MySQLDB : IDatabase {
       void Connect(string ...){
           MySqlConnection connection = new MySqlConnection(connectionString);
           ...
       }
    
        // same for query, etc
    }
    
    public class OracleDB : IDatabase {
       void Connect(string ...){
           // connect using Oracle library
           ...
       }
    
        // same for query, etc
    }
