    private MySqlConnectionStringBuilder sConnString = new MySqlConnectionStringBuilder
    {
        Server = "",
        UserID = "",
        Password = "",
        Database = ""
    };
    
    private void Test(){
    
    	// open connection to db
    	using (MySqlConnection conn = new MySqlConnection(sConnString))
    	{
    	    using (MySqlCommand cmd = conn.CreateCommand())
    	    {
    	        try
    	        {
    		        conn.Open();
    	            cmd.CommandText = "SELECT * FROM foo WHERE OrderID = @OrderID";
    
    	            // Add any params
    	            cmd.Parameters.AddWithValue("@OrderID", "1111");
    	            cmd.Prepare();
    	            cmd.ExecuteNonQuery();
    	        }
    	        catch (Exception e)
    	        {
    	        	MessageBox.Show(e.ToString());
    	            return;
    	        }
    	    }
    	}
    }
