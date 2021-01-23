    using(var sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
    {
    	sqlConn.Open();
    	
    	SqlCommand sqlComm = new SqlCommand("SELECT Price FROM Pricing WHERE FoodID = 1", sqlConn);
    	
    	using(var reader = sqlComm.ExecuteReader())
    	{
    		while (reader.Read())
    		{
    			var price1 = reader["Price"];
    		}
    	}
    }
