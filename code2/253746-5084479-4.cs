    SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings
                                         [YOUR_CONNECTION_STRING_NAME].ConnectionString);  
    SqlCommand cmd = new SqlCommand();  
    cmd.CommandText = "usp_AddMyRecords";  
    cmd.CommandType = CommandType.StoredProcedure;  
    cmd.Connection = dbConnection;  
    conn.Open();
    cmd.ExecuteNonQuery();
