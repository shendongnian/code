    string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = ConnectionDb; Integrated Security = True";
    
    using (SqlConnection sqlCon = new SqlConnection(connectionString))
    {
    	string email = textBox1.Text.Trim();
    	string pwd = textBox2.Text.Trim();
    
    	string sql = "Select [AdminYes] From UsersConfig where Email=@user and Password=@password";
    
    	SqlCommand command = new SqlCommand(sql, sqlCon);
    	command.Parameters.AddWithValue("@user", email);
    	command.Parameters.AddWithValue("@password", pwd);
    
    	try
    	{
    		command.Connection.Open();
    		object result = command.ExecuteScalar();
    
    		if (result == null)
    		{
    			MessageBox.Show("Invalid credentials!");
    		}
    		else if (result.ToString() == "1")
    		{
    			MessageBox.Show("Has admin");
    			Form adminpanel = new AdminPanel();
    			adminpanel.Show();
    			this.Hide();
    		}
    		else
    		{
    			MessageBox.Show("Hasn't got admin");
    		}
    	}
    	catch (SqlException ex)
    	{
    		MessageBox.Show("Database errors!");
    	}
    }
