    namespace databaseFunctions
    {
        public class databaseConnection:IDisposable
        {
            private OdbcConnection con;
    
            private static string databaseConnectionString()
            {
                return "DRIVER={MySQL ODBC 5.1 Driver}; ........";
            }
    
            public void OpenConnection(){
                if (con == null || con.IsClosed ){ // we make sure we're only opening connection once.
                    con = new OdbcConnection(...);
                }
            }
            public void CloseConnection(){
                if (con != null && con.IsOpen){ // I'm making stuff up here
                    con.Close();
                }
            }
    
            public DataTable getFromDatabase(string SQL)
            {
                OpenConnection();
    
                DataTable rt = new DataTable();
                DataSet ds = new DataSet();
                OdbcCommand cmd = new OdbcCommand(SQL, con);
                da.SelectCommand = cmd;
                da.Fill(ds);
                try
                {
                    rt = ds.Tables[0];
                }
                catch
                {   
                    rt = null;
                }
                return rt;
            }
    
            public Boolean insertIntoDatabase(string SQL)
            {
                OpenConnection();
    
                OdbcCommand cmd = new OdbcCommand(SQL, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
    
            }
    
    
            // Implementing IDisposable method
            public void Dispose(){
                CloseConenction();
            }
        }
    }
