    public static string UpdatePassword(string user, string password)
    {
        using (var connection = new OleDbConnection(connectionString))
        using (var command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = "UPDATE Password_Table SET Password = @pwd WHERE Password_ID = @user";
            command.Parameters.AddWithValue("@pwd", password);
            command.Parameters.AddWithValue("@user", user);
            try
            {
                return command.ExecuteNonQuery();
            }
            catch
            {
                return -1;//for error
            }
        }
    }
