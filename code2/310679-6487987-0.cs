    using (MySqlConnection connection = new MySqlConnection(MyConString))
    {
        using (MySqlCommand command = connection.CreateCommand())
        {
           command.Connection = connection;
           /// the rest of your database code goes here
           command.ExecuteNonQuery();
    }
    MessageBox.Show("Data Saved");
