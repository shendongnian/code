    class MyClass
    {
    	private Dictionary<string, int> intValues = new Dictionary<string, int>();
    	private Dictionary<string, double> doubleValues = new Dictionary<string, double>();
    	private Dictionary<string, DateTime> dateTimeValues = new Dictionary<string, DateTime>();
    
    	public MyClass(params object[] values)
    	{
    		if (values.Length % 2 != 0)
    			throw new ArgumentException("invalid values!", "values");
    		for (int i = 0; i < values.Length; i += 2)
    		{
    			string key = values[i].ToString();
    			object value = values[i + 1];
    			if (value is int)
    				intValues.Add(key, (int)value);
    			else if (value is double)
    				doubleValues.Add(key, (double)value);
    			else if (value is DateTime)
    				dateTimeValues.Add(key, (DateTime)value);
    		}
    	}
    }
