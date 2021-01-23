    //ensures the SQLconnection will be closed...
    using (SqlConnection connection =
               new SqlConnection(connectionString))
    {
        SqlCommand command =
            new SqlCommand("select * from MyTable", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        // Reads data
        while (reader.Read())
        {
            Response.Write(String.Format("{0}, {1}",
                reader[0], reader[1]));
        }
        // Close dataReader after use...
        reader.Close();
    }
