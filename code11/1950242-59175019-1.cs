    public static void SavedData(int _SomeField)
    {
    
    	FooModel data = new FooModel
    	{
    		SomeField = _SomeField
    	};
    
    	MySqlConnection dbConnection;
    
    	MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder();
    
    	connectionBuilder.Server = "localhost";
    	connectionBuilder.UserID = "root";
    	connectionBuilder.Password = "password";
    	connectionBuilder.Database = "foo";
    
    	dbConnection = new MySqlConnection(connectionBuilder.ToString());
    
    
    	String query = String.Format("insert into foo.foo (SomeField) values ('{0}')", @data.SomeField);
    
    	dbConnection.Open();
    
    	MySqlCommand cmd = new MySqlCommand(query, dbConnection);
    
    	cmd.ExecuteNonQuery();
    
    	dbConnection.Close();
    
    }
