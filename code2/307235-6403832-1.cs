    using (var conn = new MySqlConnection(SQLStringClass.masterConString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT Foo FROM Bar";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                ...
            }
        }
    }
