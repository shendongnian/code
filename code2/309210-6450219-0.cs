    public bool IsValid(string username, string password)
    {
        using (var conn = new OdbcConnection("host=localhost;usr=root;password=admin;db=timekeeping;"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT count(*) FROM receptionist WHERE username = @username AND password = @password;";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            var count = (long)cmd.ExecuteScalar();
            return count > 0;
        }
    }
