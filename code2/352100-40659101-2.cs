    public class WebDemoContext
    {
        private SqlConnection Conn;
        private string connStr = ConfigurationManager.ConnectionStrings["WebAppDemoConnString"].ConnectionString;
        protected void connect()
        {
            Conn = new SqlConnection(connStr);
        }
        public class WebAppDemo_ORM : WebDemoContext
        {
            public int UserID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string UserPassword { get; set; }
            public int result = 0;
            public void RegisterUser()
            {
                connect();
                SqlCommand cmd = new SqlCommand("dbo.RegisterUser", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("FirstName", FirstName);
                cmd.Parameters.AddWithValue("LastName", LastName);
                cmd.Parameters.AddWithValue("Phone", Phone);
                cmd.Parameters.AddWithValue("Email", Email);
                cmd.Parameters.AddWithValue("UserName", UserName);
                cmd.Parameters.AddWithValue("UserPassword", UserPassword);
                try
                {
                    Conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    DBErrorLog.DbServLog(se, se.ToString());
                }
                finally
                {
                    Conn.Close();
                }
            }
        }
    }
