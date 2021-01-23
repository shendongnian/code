    public static SqlConnection GetConnection()
    {
        string conString = ConfigurationManager.ConnectionStrings["connName"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        return con;
    }
