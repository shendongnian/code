    void Main()
    {
    	var myC = new C { Abc = "Hello!" };
    	var t = typeof(C);
    	foreach (var prop in t.GetProperties())
    	{
    		var attr = prop.GetCustomAttributes(typeof(StringLengthAttribute), true).Cast<StringLengthAttribute>().FirstOrDefault();
    		if (attr != null)
    		{
    			var attrValue = attr.MaximumLength; // 100
    			var propertyValue = prop.GetValue(myC, null); // "Hello!"
    		}
    	}
    }
    class C
    {
    	[StringLength(100)]
    	public string Abc {get;set;}
    }
