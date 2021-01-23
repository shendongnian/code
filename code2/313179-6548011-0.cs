    //
	// The name we are trying to match.
	//
	string dogName = "Fido";
	//
	// Use preset string for connection and open it.
	//
	string connectionString = ConsoleApplication716.Properties.Settings.Default.ConnectionString;
	using (SqlConnection connection = new SqlConnection(connectionString))
	{
	    connection.Open();
	    //
	    // Description of SQL command:
	    // 1. It selects all cells from rows matching the name.
	    // 2. It uses LIKE operator because Name is a Text field.
	    // 3. @Name must be added as a new SqlParameter.
	    //
	    using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1 WHERE Name LIKE @Name", connection))
	    {
		//
		// Add new SqlParameter to the command.
		//
		command.Parameters.Add(new SqlParameter("Name", dogName));
		//
		// Read in the SELECT results.
		//
		SqlDataReader reader = command.ExecuteReader();
		while (reader.Read())
		{
		    int weight = reader.GetInt32(0);
		    string name = reader.GetString(1);
		    string breed = reader.GetString(2);
		    Console.WriteLine("Weight = {0}, Name = {1}, Breed = {2}", weight,    name, breed);
		}
	    }
	}
