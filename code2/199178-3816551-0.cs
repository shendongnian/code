    class Guy {
    	private static readonly Dictionary<string, string> mappings = new Dictionary<string, string> {
    		{ "Name", "nameProp" },
    		{ "Age", "ageProp" }
    	};
    	
    	public string Name { get; set; }
    	public int Age { get; set; }
    	
    	public void RetrieveProperties (Func<string, object> valueRetriever)
    	{
    		foreach (var prop in GetType ().GetProperties (BindingFlags.Instance | BindingFlags.Public)) {
    			var mapping = mappings [prop.Name];
    			var value = valueRetriever (mapping);
    			
    			prop.SetValue (this, value, null);
    		}
    	}
    	
    	public override string ToString ()
    	{
    		return string.Format ("I'm {0}, {1} years old.", Name, Age);
    	}
    }
    	
    
    public static class Program
    {
    	static object GetItemPropertyValue (string itemName)
    	{
    		if (itemName == "nameProp")
    			return "John";
    			
    		if (itemName == "ageProp")
    			return 42;
    			
    		throw new NotImplementedException ();
    	}
    	
    	public static void Main ()
    	{
    		var john = new Guy ();
    		john.RetrieveProperties (GetItemPropertyValue);
    		
    		Console.WriteLine (john);
    	}
    }
