    // connection for reader
    using (SqlConnection connection1 = new SqlConnection(connectionString))
    using (SqlCommand command1 = new connection1.CreateCommand())
    {
        command1.CommandText = commandText1;
    
        connection1.Open();
        using (SqlDataReader reader = command1.ExecuteReader())
        {
            // fill table in loop
            while (reader.Read())
            {
                string stateincharge = reader["stateincharge"].ToString();
                string email = reader["email"].ToString();
                // connection for adapter
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                using (SqlCommand command2 = new connection2.CreateCommand())
                {
                    command2.CommandText = commandText2;
                    command2.Parameters.AddWithValue("@stateincharge", stateincharge);
                    command2.Parameters.AddWithValue("@email ", email );
    
                    connection2.Open();
    
                    DataTable dt = new DataTable();
                    using (SqlDataApapter ad = new SqlDataAdapter 
                    {
                        ad.Fill(dt);
                        // yield return dt;
                    }
                }
            }
        }
    }
