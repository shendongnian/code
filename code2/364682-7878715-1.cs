            try
            {
                Database.Open(); // Custom class that has our connection string hard coded.
                string query = "SELECT * FROM table"; // (dummy query)
                using (SqlCommand command = new SqlCommand(query, Database.Conn))
                using (SqlDataReader reader = command.ExecuteReader(CommandBehaviour.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Do something with the data.
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
