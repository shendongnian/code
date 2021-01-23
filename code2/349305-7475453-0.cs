    public class myDAL:IDisposable
     {
        protected SqlConnection sqlConnection = new SqlConnection();
        protected void openConnection(string connection)
        {
                sqlConnection.ConnectionString = connection;
                sqlConnection.Open();            
        }
        protected void closeConnection()
        {            
            sqlConnection.Close();
        }
        public void Dispose()
        {
            sqlconnection.Close();
           //Dispose of the connection
        }
     } 
