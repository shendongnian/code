    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
    using(var command = new MySqlCommand(query1, con))
    {
        using(var reader = command.ExecuteReader())
        {
           while (reader.Read())
           {
            date_min = Convert.ToDateTime(reader[0]);
            date_max = Convert.ToDateTime(reader[1]);
           }
        }
    }
    }
