    using (var conn = new SqlConnection(SomeConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT * FROM learer WHERE id = @id";
        cmd.Parameters.AddWithValue("@id", index);
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                learerLabel.Text = reader.GetString(reader.GetOrdinal("somecolumn"))
            }
        }
    }
