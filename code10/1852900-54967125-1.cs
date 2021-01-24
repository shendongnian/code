    using (MySqlConnection connection = new MySqlConnection(myConnectionString))
    {
       using (MyDbContext contextDB = new MyDbContext(connection, false))
       {
          contextDB.Database.CreateIfNotExists();
       }
    }
