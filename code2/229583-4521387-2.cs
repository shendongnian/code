    string firstname = "John";
    using (var conn = new SqlConnection("Server=myServerAddress;Database=myDataBase;User ID=myUsername;Password=myPassword;Trusted_Connection=False;"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT lastname FROM mytable WHERE firstname = @firstname;";
        cmd.Parameters.AddWithValue("@firstname", firstname);
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string lastName = reader.GetString(0);
                // do something with the value
            }
        }
    }
