    string sql =
     "SELECT categoryDB, number FROM tableName WHERE titleDBColumn LIKE @input";
    using (var conn = new MySqlConnection(connStr)) {
        var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@input", titleInput);
        conn.Open();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            ...
        }
    }
