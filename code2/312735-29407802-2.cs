    //Get Connection from web.config file
    public static OdbcConnection getConnection()
    {
        OdbcConnection con = new OdbcConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        return con;     
    }
