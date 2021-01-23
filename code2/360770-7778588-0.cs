    using (var connection = new SqlConnection(connectionString)
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "insert into URL_Entries values(@url, @now, @leak)";
    
        command.Parameters.AddWithValue("@now", DateTime.Now);
        command.Parameters.AddWithValue("@lead", leak);
    
        // update to correspond to your definition of the table column
        var urlParameter = command.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar, 100));
        
        connection.Open();
        for (int ok = 0; ok < CleanedURLlist.Length; ok++)
        {
            urlParameter.Value = CleanedURLlist[ok];
            command.ExecuteNonQuery();
        }
    }
