    static void Main(string[] args)
    {
    	DataConnectionDialog dcd = new DataConnectionDialog();
    	DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
    	dcs.LoadConfiguration(dcd);
    
    	if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
    	{
    		// load tables
    using (SqlConnection connection = new   SqlConnection(dcd.ConnectionString))
    		{
    		      connection.Open();
    			SqlCommand cmd = new SqlCommand("SELECT * FROM sys.Tables", connection);
    			using (SqlDataReader reader = cmd.ExecuteReader())
    			{
    			while (reader.Read())
    				{
    					Console.WriteLine(reader.HasRows);
    				}
    			}
           	}
    	}
    	dcs.SaveConfiguration(dcd);
    }
