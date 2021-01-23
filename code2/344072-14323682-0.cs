    class clsConnectionClass:IDisposable
    {
        public SqlConnection cnn;
       
        public clsConnectionClass()
        {
            if ((cnn = _cnn()) == null)
            {
                this.Dispose();
            }
        }
        private SqlConnection _cnn()
        {
            SqlConnection conn = null;
            string server =  "Your server address or name"             
            string db = "Your dadabase name";
            cnnString = string.Format("Server={0};Database={1};Trusted_Connection=SSPI;",server,db);
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = cnnString;
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }
        public void Dispose()
        {
            if (cnn != null)
            {
                cnn.Dispose();
            }
        }
    }
