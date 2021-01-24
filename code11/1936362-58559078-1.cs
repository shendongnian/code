    public SqlConnection ValidateEnvironment()
        {
            SqlConn = new SqlConnection();
            string hostName = System.Net.Dns.GetHostName();
    
            setHost = ConfigurationManager.AppSettings["MyServerConfig"].ToString();
            //Set our SqlConnection based on what was provided by host
            SqlConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[setHost].ConnectionString;
    
            return SqlConn;
        }
