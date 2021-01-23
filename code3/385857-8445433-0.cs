    public void Connect(string user)
    {
        switch(user)
        {
            case "Default":
            {
                m_connectionString = ConfigurationManager.ConnectionStrings["ApplicationDefault"].ConnectionString;
                break;
            }
            case "Oracle":
            {
                m_connectionString = ConfigurationManager.ConnectionStrings["OracleDefault"].ConnectionString;
                break;
            }
        }
        //now connect to the database
    }
