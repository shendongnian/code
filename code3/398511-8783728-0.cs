    [AttributeUsage(AttributeTargets.Property, AllowMultiple= false)]
    class JQueryFieldNameAttribute : Attribute {
    	
    	public string Name { get; private set; }
    	
    	public JQueryFieldNameAttribute(string name)
    	{
    		Name = name;
    	}
    }
    
    class Model {
    	[JQueryFieldName("#clientid")]
    	public string Foo { get; set; }
    }
    
    void Main()
    {
    	var type = typeof(Model);
    	
    	var attributes = type.GetProperties()
    						 .SelectMany (t => t.GetCustomAttributes(typeof(JQueryFieldNameAttribute), true));
    	
    	var cache = new Dictionary<int, JQueryFieldNameAttribute>();
    	
    	// Cache results for this type only
    	cache.Add(type.GetHashCode(), attributes);
    	
    	foreach (JQueryFieldNameAttribute a in attributes)
    	{
    		Console.WriteLine (a.Name);
    	}	
    }
