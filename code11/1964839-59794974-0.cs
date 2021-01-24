    string commandText = "insert into books_info values(@val1, @val2, @val3, @val4, @val5, @val6)";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	SqlCommand command = new SqlCommand(commandText, connection);
    	command.Parameters.AddWithValue("@val1", textBox1.Text);
    	command.Parameters.AddWithValue("@val2", textBox2.Text);
    	command.Parameters.AddWithValue("@val3", textBox3.Text);
    	command.Parameters.AddWithValue("@val4", dateTimePicker1.Value);
    	command.Parameters.AddWithValue("@val5", textBox5.Text);
    	command.Parameters.AddWithValue("@val6", textBox6.Text);
    
    	try
    	{
    		connection.Open();
    		command.ExecuteNonQuery();
    	}
    	catch (Exception ex)
    	{
    		//handle the error
    	}
    }
