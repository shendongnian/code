    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = ConfigurationManager
        .ConnectionStrings["MyDBConnectionString"].ConnectionString;
    try
    {
        conn.Open();                
    }
    catch (Exception)
    {
        throw;
                    
    }
