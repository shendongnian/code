    private void ExecNonQuery(string sqlStatement)
    {          
        using (var conn = new MySqlConnection(connString))
        {
           using (var cmd = new MySqlDataCommand(conn))
           {
               cmd.ExecuteNonQuery(sqlStatement);
           }
        }
    }
