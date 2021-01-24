    using (IDbConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString))
    {
    	Test tobj = new Test();
    	tobj.One = "hello";
    	tobj.Two = 123;
    	
    	con.Execute("INSERT INTO test (one, two) VALUES (@One, @Two)", new 
    	{
    		One = tobj.One,
    		Two = tobj.Two
    	});
    }
