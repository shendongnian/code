    using (var conn = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand($"SELECT Last_Login_Date FROM [dbo].[Member] WHERE EmailAddress='{emailAddress}';"))
    {
        DateTime lastlogindate;
        cmd.Connection = conn;
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            lastlogindate = reader.GetDateTime("Last_Login_Date");
            //add your comparision logic here        
            Console.WriteLine(DateTime.Compare(lastlogindate, DateTime.Now)); //result -1    
        }
    }
