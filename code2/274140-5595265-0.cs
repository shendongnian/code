    using (var connection = new MySqlConnection(myConnectionString)
    {
        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText = "Insert into yourtable";
            cmd.ExecuteNonQuery();
        }
    }
