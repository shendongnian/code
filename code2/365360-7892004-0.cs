    private void populate()
    {
    	String connectionString = Properties.Settings.Default.Database;
    
    	String selectString = "select artikelnummer, omschrijving from Artikels";
    
    	SqlDataReader reader = null;
    
    	SqlConnection connection = new SqlConnection(connectionString);
    	SqlCommand command = new SqlCommand(selectString);
    	connection.Open();
    	reader = command.ExecuteReader();
    	int x = 0;
    	while (reader.Read())
    	{
    		String item = String.Empty;
    		item = Convert.ToString(reader["Artikelnummer"]) + "\t" + Convert.ToString(reader["Omschrijving"]);
    		x++;
    		listboxGeselecteerd.Items.Add(item);
    	}
    	reader.Close();
    	connection.Close();
    }
