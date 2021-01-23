    private bool ValidateUserById(string connString, int id)
    {
        using (var conn = new SqlConnection(connString))
        {
            conn.Open();
                  
            var sqlString = string.Format("Select * From Users where Id = {0}", id);
            using (var cmd = new SqlCommand(sqlString, conn))
            {
                    return cmd.ExecuteScalar() != null;
            }
        }
    }
