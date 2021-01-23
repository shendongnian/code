    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var insertCommand = new SqlCommand(
            @"INSERT INTO tb_User (ID, f_Name, l_Name)
              VALUES (@ID, 'Ted', 'Turner')", connection))
        {
            insertCommand.Parameters.AddWithValue("@ID", userID);
            insertCommand.ExecuteNonQuery();
        }
    }
