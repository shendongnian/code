    using (var q = SqlHelper.ExecuteReader("MyConection", "MySP", params))
    {
    	System.Diagnostics.Debug.WriteLine(stop.Elapsed);
    	List<Cliente> clientes = new List<Cliente>();
    
    
    	// Build your own list in the same order you are reading them in
    	List<int> myOrdinal = new List<int>();
    	myOrdinal.Add(q.GetOrdinal("ID"));
    	myOrdinal.Add(q.GetOrdinal("Field1"));
    	myOrdinal.Add(q.GetOrdinal("Field2"));
    	myOrdinal.Add(q.GetOrdinal("Field3"));
    	myOrdinal.Add(q.GetOrdinal("Field4"));
    	myOrdinal.Add(q.GetOrdinal("Field5"));
    	myOrdinal.Add(q.GetOrdinal("Field6"));
    	myOrdinal.Add(q.GetOrdinal("Field7"));
    	myOrdinal.Add(q.GetOrdinal("Field8"));
    	myOrdinal.Add(q.GetOrdinal("Field9"));
    	myOrdinal.Add(q.GetOrdinal("Field10"));
    	myOrdinal.Add(q.GetOrdinal("Field11"));
    	myOrdinal.Add(q.GetOrdinal("Field12"));
    	myOrdinal.Add(q.GetOrdinal("Field13"));
    	myOrdinal.Add(q.GetOrdinal("Field14"));
    
    	while (q.Read())
    	{
    		clientes.Add(new Cliente()
    		{
    			// then use your list of ordinal values directly
    			Id = q.GetInt32(myOrdinal[0]),
    			Field1 = q.GetString(myOrdinal[1]),
    			Field2 = q.GetString(myOrdinal[2]),
    			Field3 = q.GetString(myOrdinal[3]),
    			Field4 = q.GetInt32(myOrdinal[4]),
    			Field5 = q.GetString(myOrdinal[5]),
    			Field6 = q.GetString(myOrdinal[6]),
    			Field7 = q.GetString(myOrdinal[7]),
    			Field8 = q.GetDateTime(myOrdinal[8]),
    			Field9 = q.GetInt32(myOrdinal[9]),
    			Field10 = q.GetString(myOrdinal[10]),
    			Field11 = q.GetString(myOrdinal[11]),
    			Field12 = q.GetString(myOrdinal[12]),
    			Field13 = q.GetDateTime(myOrdinal[13]),
    			Field14 = q.GetString(myOrdinal[14]),
    
    		});
    		System.Diagnostics.Debug.WriteLine(stop.Elapsed);
    	}
    	System.Diagnostics.Debug.WriteLine(stop.Elapsed);
    	stop.Stop();
    	return clientes;
    }
