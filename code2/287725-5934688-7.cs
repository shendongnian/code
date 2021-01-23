    /* Implement IDisposable to cleanup connection */
    public class Connexion_D : IDisposable 
    {
        public SqlConnection conn;
        
        public SqlConnection GetConnected()
        {
            try
            {
                String strConnectionString = ConfigurationManager.ConnectionStrings["xxxxx"].ConnectionString;
                conn = new SqlConnection(strConnectionString);
            }
            catch (Exception excThrown)
            {
                conn = null;
                throw new Exception(excThrown.InnerException.Message, excThrown);
            }
            // Ouverture et restitution de la connexion en cours
            if (conn.State == ConnectionState.Closed) conn.Open();
            return conn;
        }
        public Boolean IsConnected
        {
            get { return (conn != null) && (conn.State != ConnectionState.Closed) && (conn.State != ConnectionState.Broken); }
        }
        public void CloseConnection()
        {
            // Libération de la connexion si elle existe
            if (IsConnected) { 
                conn.Close();
                conn = null;
            }
        }
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            // Close connection
        }
    }
