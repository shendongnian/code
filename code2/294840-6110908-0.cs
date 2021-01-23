     using (SqlConnection connection = new SqlConnection(ConnectionString))     
        {         
        string query = "INSERT INTO SocialGroup (created_by_fbuid) VALUES (@FBUID);";         
        SqlCommand command = new SqlCommand(query, connection);            
        command.Parameters.AddWithValue("@FBUID", FBUID);         
         connection.Open();         
        command.ExecuteNonQuery();
         query = "SELECT CAST(scope_identity() AS int)";     
         command = new SqlCommand(query, connection);                   
        int lastID = (int)command.ExecuteScalar();      
        } 
