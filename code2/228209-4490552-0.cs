        DataTable table = new DataTable();
        using ( SqlCommand command = new SqlCommand() )
        {
               // TODO: Set up your command here
        	using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        	{
        		adapter.Fill(table);
        	}
        }
    
        // Use your DataTable like this...
        
        if ( table.Rows.Count >= 5 ) {
            DataRow firstRow = table.Rows[0]; // #1 row
            DataRow fifthRow = table.Rows[4]; // #5 row
            DataRow secondRow = table.Rows[1]; // #2 row
        }
