    public static bool InsertUser(string userName, string password, string type)
    {
        try
        {
            using (var connection = new SqlConnection("data source=.; integrated security=true; initial catalog=test;"))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into users (username, pass, type) values (@username, @password, @type)";
                command.Parameters.AddWithValue("username", userName);
                command.Parameters.AddWithValue("password", password);
                command.Parameters.AddWithValue("type", type);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }
