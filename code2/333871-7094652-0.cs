    public static DataTable AsDataTable<T>(this IEnumerable<T> enumerable)
    {
    	if (enumerable == null)
    	{
    		throw new ArgumentNullException("enumerable");
    	}
    
    	DataTable table = new DataTable();
    	if (enumerable.Any())
    	{
    		IList<PropertyInfo> properties = typeof(T)
    											.GetProperties()
    											.Where(p => p.CanRead && (p.GetIndexParameters().Length == 0))
    											.ToList();
    
    		foreach (PropertyInfo property in properties)
    		{
    			table.Columns.Add(property.Name, property.PropertyType);
    		}
    
    		IList<MethodInfo> getters = properties.Select(p => p.GetGetMethod()).ToList();
    
    		table.BeginLoadData();
    		try
    		{
    			object[] values = new object[properties.Count];
    			foreach (T item in enumerable)
    			{
    				for (int i = 0; i < getters.Count; i++)
    				{
    					values[i] = getters[i].Invoke(item, BindingFlags.Default, null, null, CultureInfo.InvariantCulture);
    				}
    
    				table.Rows.Add(values);
    			}
    		}
    		finally
    		{
    			table.EndLoadData();
    		}
    	}
    
    	return table;
    }
