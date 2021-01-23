    SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[YOUR_CONNECTION_STRING_NAME].ConnectionString);  
    SqlCommand cmd = new SqlCommand();  
    SqlConnection conn = dbConnection;  
    cmd.CommandText = "usp_AddMyRecords";  
    cmd.CommandType = CommandType.StoredProcedure;  
    cmd.Connection = conn;  
    conn.Open();
    cmd.ExecuteNonQuery();
