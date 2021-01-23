    public static string MultiplyThem(string[] args)
    {
        string connString = "Server=localhost;Port=3306;Database=test;Uid=root;password=p-word";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = "SELECT field_value FROM customers";
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        string myvariable = "bad";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            myvariable = reader["field_value"].ToString();
        }
        return myvariable;
    }
