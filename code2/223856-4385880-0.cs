    string strconString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLCONN"].ToString();
    using (var conn = new SqlConnection(strconString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
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
