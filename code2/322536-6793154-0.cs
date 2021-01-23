    public bool IsStudentExists(string id)
    {
        using (var conn = new SqlConnection("some connection string"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT id FROM StudentTable WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = cmd.ExecuteReader())
            {
                return reader.Read();
            }
        }
    }
