    private static void ReadOrderData(string connectionString)
    {
        string queryString = 
            "SELECT * FROM MyTable Where (FieldOne == @ParameterOne Or FieldTwo = @ParameterTwo Or FieldThree = @ParameterThree)";
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            // Create the command
            SqlCommand command = new SqlCommand(
                queryString, connection);
            // Add the parameters
            command.Parameters.Add(new SqlParameter("ParameterOne", txtMyTextBox1.Text));
            command.Parameters.Add(new SqlParameter("ParameterTwo", txtMyTextBox2.Text));
            command.Parameters.Add(new SqlParameter("ParameterThree", txtMyTextBox3.Text));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }
    }
