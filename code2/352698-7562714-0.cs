    public static dynamic DynamicWeirdness()
    {
    	dynamic ex = new ExpandoObject();
    	ex.TableName = "Products";
    	using (var conn = OpenConnection()) {
    	    var cmd = CreateCommand((ExpandoObject)ex);
    	    cmd.Connection = conn;
    	}
    	Console.WriteLine("It worked!");
    	Console.Read();
    	return null;
    }
