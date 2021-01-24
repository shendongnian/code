    using(MySqlConnection connect = new MySqlConnection(dbConnectionString))
    using(MySqlCommand cmd = new MySqlCommand())
    {
        cmd.CommandText = query2;
    
        cmd.Connection = connect;
        cmd.Connection.Open();
    
        using(MySqlDataReader msdr = cmd.ExecuteReader())
        {
             // do stuff
        }
    }
