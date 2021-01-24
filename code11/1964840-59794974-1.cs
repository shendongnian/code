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
    	
    	//OR DO THIS INSTEAD. SEE COMMENTS ON WHY AddWithValue IS NOT ALWAYS THE BEST CHOICE. 
    	//FOR THIS, THE SQL TYPES AND FIELD LENGTHS SHOULD MATCH WHAT YOU ARE USING IN YOUR 
    	//  DATABASE AND APPLICATION.
    	command.Parameters.Add("@val1", SqlDbType.NVarChar, 64).Value = textBox1.Text;
    	command.Parameters.Add("@val2", SqlDbType.NVarChar, 64).Value = textBox2.Text;
    	command.Parameters.Add("@val3", SqlDbType.NVarChar, 64).Value = textBox3.Text;
    	command.Parameters.Add("@val4", SqlDbType.DateTime).Value = dateTimePicker1.Value;
    	command.Parameters.Add("@val5", SqlDbType.NVarChar, 64).Value = textBox5.Text;
    	command.Parameters.Add("@val6", SqlDbType.NVarChar, 64).Value = textBox6.Text;
    
    	try
    	{
    		connection.Open();
    		command.ExecuteNonQuery();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
