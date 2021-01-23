    string TName;        
    using (var conn = new SqlConnection(SomeConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT TrialName FROM dbo.CT WHERE NumId=@Trial";
        cmd.Parameters.AddWithValue("@Trial", TrialId);
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                TName  = reader["TrialName"].ToString();
            }
        }
    }
