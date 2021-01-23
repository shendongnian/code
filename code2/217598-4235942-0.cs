    using (var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mydatabase.accdb"))
    using (var command = new OleDbCommand(@"INSERT INTO IndicadorProyecto (idProyecto, idMes, meta, real) VALUES(?, ?, ?, ?") {
        command.Parameters.AddWithValue("a", idProyecto);
        command.Parameters.AddWithValue("b", idMes);
        command.Parameters.AddWithValue("c", meta);
        command.Parameters.AddWithValue("d", real);
        conn.Open();
        command.ExecuteNonQuery();
    }
