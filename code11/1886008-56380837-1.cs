    public IEnumerable<T> MapTo<T>(Root source) 
    	where T : new()
    {
    	var properties = typeof(T).GetProperties();
    	
    	foreach (var datum in source.Data)
    	{
    		var t = new T();
    		
    		for(var colIndex = 0; colIndex < source.ColumnNames.Count; colIndex++)
    		{
    			var property = properties.SingleOrDefault(p => p.Name.Equals(source.ColumnNames[colIndex], StringComparison.InvariantCultureIgnoreCase));
    			if (property != null)
    			{
    				property.SetValue(t, Convert.ChangeType(datum[colIndex], property.PropertyType));
    			}
    		}
    		yield return t;
    	}
    }
