    using (var connection = new SqlConnection(connection string))
    using (var command = new SqlCommand("INSERT ... ", connection)) {
        command.Parameters.AddWithValue("name", someValue);
        connection.Open();
        command.ExecuteNonQuery();
    }
