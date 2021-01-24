    using (var connection = new MySqlConnection(_dbUrl))
    {
        connection.Open();
        using (var cmd = new MySqlCommand("GetProjectVM", connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            // Avoid AddWithValue where possible, to avoid conversion issues.
            cmd.Parameters.Add("@projectName", MySqlDbType. VarChar).Value = projectName;
            using (var reader = cmd.ExecuteReader())
            {
                var list = new List<VM>();
                while (reader.Read())
                {
                    list.Add(new VM(reader));
                }
                return list;
            }
        }
    }
