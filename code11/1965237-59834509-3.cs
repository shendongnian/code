            string connectionstring = @"Connectionstring";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("InsertLog",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@error", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
