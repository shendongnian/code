    public class FCSConnection : IDisposable
    {
        private SqlConnection connection = null;
    
        public string GetDefaultConnectionString()
        {   
            string defaultConnectionString = null;
            try
            {
                defaultConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                connection = new SqlConnection(defaultConnectionString);
                connection.Open(); // are you sure want to keep the connection being opened??
            }
            catch
            {
                Dispose();
            }
            return defaultConnectionString;
        }
    
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }        
    }
