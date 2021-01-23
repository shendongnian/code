    public class DataLayer
    {
       private DbConnection GetConnection()
       {
            //This could also be a connection for OleDb, ODBC, Oracle, MySQL, 
            // or whatever kind of database you have.
            //We could also use this place (or the constructor) to load the 
            // connection string from an external source, like a
            // (possibly-encrypted) config file
            return new SqlConnection("connection string here");
       }
    }
