    protected SqlConnection connection 
    {
        get
        {
            return new SqlConnection
              (System.Web.Configuration.WebConfigurationManager.ConnectionStrings 
              ["DefaultConnectionString"].ConnectionString); 
        }
    }
