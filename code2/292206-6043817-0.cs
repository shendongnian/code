    using (SqlConnection c = new SqlConnection(
		Properties.Settings.Default.DataConnectionString))
	    {
		c.Open();
		// Create new DataAdapter
		using (SqlDataAdapter a = new SqlDataAdapter("SELECT Mod_Naam, Mod_Omschrijving FROM Model WHERE Mod_ID = @modid ", c))
		{
            a.SelectCommand.Parameters.AddWithValue("modid", "");
		    
		    // Use DataAdapter to fill DataTable
		    DataTable t = new DataTable();
		    a.Fill(t);
	    
		    // GridView1.DataSource = t; // <-- From your designer
		}
	    }
