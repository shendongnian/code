    using (var connection1 = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand($"SELECT Last_Login_Date FROM [dbo].[Member] WHERE EmailAddress='{emailAddress}';"))
    {
        DateTime lastlogindate;
        cmd.Connection = connection1;
        connection1.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        int colIndex = reader.GetOrdinal("Last_Login_Date");
        if (colIndex>0 && !reader.IsDBNull(colIndex))
        {
            lastlogindate = reader.GetDateTime(colIndex);
            //add your comparision logic here
        }
    }
