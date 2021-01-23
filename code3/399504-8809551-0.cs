    string connectionString = ConfigurationManager.ConnectionStrings["KpH2Oprod"].ConnectionString;
    
    using( SqlConnection sc = new SqlConnection( connectionString ) )
    {
        sc.Open();
        // perform simple data access
    }
