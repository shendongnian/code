    connection.Open();
    using (SqlCommand command = new SqlCommand("INSERT INTO USERS(hwid) VALUES(@HWID)", connection))
    {
        command.Parameters.AddWithValue("@HWID", HWID);
        command.ExecuteNonQuery();  // ADD THIS LINE
    }
    connection.Close();
