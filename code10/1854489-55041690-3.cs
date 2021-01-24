    private void check_Click(object sender, EventArgs e)
    {
    	string insertQuery = "INSERT INTO tbl_phones(model) VALUES(@model)";
    
    	using (SqlConnection sqlconn = new SqlConnection(connectionString))
    	{
    		sqlconn.Open();
    
    		SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconn);
    		insertCommand.Parameters.AddWithValue("@model", "test");
    
    		try
    		{
    			insertCommand.ExecuteNonQuery();
    		}
    		
    		catch(SqlException ex)
    		{
    			if (ex.Number == 2627)
    			{
    				// Phone already exists, do some stuff
    			}
    
    			else throw;
    		}
    	}
    }
