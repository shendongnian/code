    List<string> connectionStrings = new List<string>();
    connectionStrings.Add("Server=myServerAddress;Database=myDataBase1;User Id=myUsername;Password=myPassword;");
    connectionStrings.Add("Server=myServerAddress;Database=myDataBase2;User Id=myUsername;Password=myPassword;");
    foreach (string connectionString in connectionStrings)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand("ProcedureName", conn)) 
            {
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
