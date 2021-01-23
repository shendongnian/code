	try
	{
		MySqlConnection connection = new MySqlConnection(MyConString);
		MySqlCommand command = connection.CreateCommand();
		MySqlDataReader Reader;
		//Change the "username" and "password" to the corresponding names of these columns in your table
		command.CommandText = "select * from users where username = @username AND password = @password";
		command.Parameters.AddWithValue("@username", textBox4.Text); //assuming textbox 4 has the password
		command.Parameters.AddWithValue("@password", CryptorEngine.Encrypt(textBox5.Text, true));
		
		try
		{
			connection.Open();
		}
		catch (Exception ex)
		{
			listBox4.Items.Add(ex);
			MessageBox.Show("There has been an error connecting to the user database! Please try again later.");
		}
		
		Reader = command.ExecuteReader();
		if(Reader.HasRows){
			MessageBox.Show("Successfully logged in!");
		}
		else
		{
			MessageBox.Show("Wrong Username/Password Combination");
		}
		
		
		connection.Close();
	}
	catch (Exception ex)
	{
		listBox4.Items.Add(ex);
	}
