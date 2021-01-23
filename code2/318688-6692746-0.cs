    using (SqlCommand cmd = new SqlCommand(commandText, connection, null))
    {
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                testID = (int)reader["id"];
            }
        }
    }
