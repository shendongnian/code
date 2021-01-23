    using (var conn = new SqlConnection(connString))
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = createTableStatement; //CREATE TABLE Foo (ID int);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = createIndexStatement;
            cmd.ExecuteNonQuery();
        }
    }
