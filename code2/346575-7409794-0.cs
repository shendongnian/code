    using (var conn = new SqlConnection(SomeConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT foo, bar FROM baz;";
        using (var reader = cmd.ExecuteReader())
        {
            using (var writer = new StreamWriter("result.txt"))
            {
                while (reader.Read())
                {
                    var foo = reader.GetString(reader.GetOrdinal("foo"));
                    var bar = reader.GetInt32(reader.GetOrdinal("bar"));
                    writer.WriteLine(string.Format("{0}, {1}", foo, bar));
                }
            }
        }
    }
