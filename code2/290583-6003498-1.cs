    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand("select * from Requests where Complete = 0", connection))
    {
        connection.Open();  
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader["Username"].ToString());
                Console.WriteLine(reader["Item"].ToString());
                Console.WriteLine(reader["Amount"].ToString());
                Console.WriteLine(reader["Complete"].ToString());
            }
        }
    }
