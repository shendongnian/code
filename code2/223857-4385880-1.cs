    var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLCONN"].ToString();
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select status from racpw where vtgid = @vtgid";
            cmd.Parameters.AddWithValue("@vtgid", vtgid);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ...
                }
            }
        }
    }
