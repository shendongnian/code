    using(var connection1 = new SqlConnection(connectionString))
    using(var cmd = new SqlDataAdapter())
    using(var insertCommand = new SqlCommand($"SELECT Last_Login_Date FROM [dbo].[Member] WHERE EmailAddress='{emailAddress}');"))
    {
    	DateTime lastlogindate;
        insertCommand.Connection = connection1;
        connection1.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        int colIndex = reader.GetOrdinal("Last_Login_Date");
        if(!reader.IsDBNull(colIndex ))
        {
            lastlogindate = reader.GetDateTime(colIndex);
            //add your comparision logic here
        }
    }
