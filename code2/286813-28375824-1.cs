    void Main()
    {
    	dynamic foo = new ExpandoObject().Init(new
    	{
    		A = true,
    		B = "Bar"
    	});
    	
    	Console.WriteLine(foo.A);
    	Console.WriteLine(foo.B);
    }
    
    public static class ExtensionMethods
    {
    	public static ExpandoObject Init(this ExpandoObject expando, dynamic obj)
    	{
    		var expandoDic = (IDictionary<string, object>)expando;
    	    foreach (System.Reflection.PropertyInfo fi in obj.GetType().GetProperties())
            {
               expandoDic[fi.Name] = fi.GetValue(obj, null);
            }
    		return expando;
    	}
    }
