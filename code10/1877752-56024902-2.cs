    string sql = "SELECT categoryDB, number FROM `" + dbName +
             "` WHERE @input LIKE '%' + titleDBColumn + '%'";
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
