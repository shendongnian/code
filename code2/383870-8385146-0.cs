	try
	{
		using(MySqlConnection connection = new MySqlConnection(MyConString))
		using(MySqlCommand command = connection.CreateCommand())
		{
			command.CommandText = 
				@"SELECT CASE WHEN EXISTS (
					SELECT * from users 
					WHERE USERNAME = @Username AND Password = @Password
					LIMIT 1) THEN 1 ELSE 0 END";
					
			try { connection.Open(); }
			catch (Exception ex)
			{
				listBox4.Items.Add(ex);
				MessageBox.Show("There has been an error connecting to the user database! Please try again later.");
			}
			
			command.Parameters.AddWithValue("@Username", textBox4.Text);
			command.Parameters.AddWithValue("@Password", 
				CryptorEngine.Encrypt(textBox5.Text, true));
			
			Successful = (int) command.ExecuteScalar() == 1;
			MessageBox.Show(Successful
				? "Successfully logged in!"
				: "Wrong Username/Password Combination");
		}
	}
	catch (Exception ex)
	{
		listBox4.Items.Add(ex);
	}
