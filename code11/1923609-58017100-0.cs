    try{
     using (SqlConnection conn = new SqlConnection(strConnectionString))
        {
            
                conn.Open();
                string strSqlCommandText = $"CREATE USER {strUsername} for LOGIN {strUsername} WITH DEFAULT SCHEMA = [dbo];";
                SqlCommand sqlCommand = new SqlCommand(strSqlCommandText, conn);
                var sqlNonReader = sqlCommand.ExecuteNonQuery();
                if (sqlNonReader == -1) Utility.Notify($"User Added: {strUsername}");
          
        }}
    catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
