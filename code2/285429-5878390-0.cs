    SqlConnection con = new SqlConnection(myConnectionString);
    
    SqlCommand cmd = con.CreateCommand();
    cmd.CommandText = @"SELECT [stuff] FROM [tableOfStuff]";
    con.Open();
    
    SqlDataReader dr = null;
    try
    {
        dr = cmd.ExecuteReader();
        while(dr.Read())
        {
            // Populate your business objects/data tables/whatever
        }
    }
    catch(SomeTypeOfException ex){ /* handle exception */ }
    // Manually call Dispose()...
    if(con != null) con.Dispose();
    if(cmd != null) cmd.Dispose();
    if(dr != null) dr.Dispose();
