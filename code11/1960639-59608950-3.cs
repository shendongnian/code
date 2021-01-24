    using (var conn = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand($"SELECT Last_Login_Date FROM [dbo].[Member] WHERE EmailAddress='{emailAddress}';"))
    {
        DateTime lastlogindate;
        cmd.Connection = conn;
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            int colIndex = reader.GetOrdinal("Last_Login_Date");
            if (!reader.IsDBNull(colIndex))
            {
                lastlogindate = reader.GetDateTime(colIndex);
                //add your comparision logic here
            }
        }
    }
