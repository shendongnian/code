    public static object DataRowMapper(DataRow dataRow, Type type, string prefix)
    {
    	try
    	{
    		var returnObject = Activator.CreateInstance(type);
    
    		foreach (var property in type.GetProperties())
    		{
    			foreach (DataColumn key in dataRow.Table.Columns)
    			{
    				string columnName = key.ColumnName;
    				if (!String.IsNullOrEmpty(dataRow[columnName].ToString()))
    				{
    					if (String.IsNullOrEmpty(prefix) || columnName.Length > prefix.Length)
    					{
    						String propertyNameToMatch = String.IsNullOrEmpty(prefix) ? columnName : columnName.Substring(property.Name.IndexOf(prefix) + prefix.Length + 1);
    						propertyNameToMatch = propertyNameToMatch.ToPascalCase();
    						if (property.Name == propertyNameToMatch)
    						{
    
    							Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
    
    							object safeValue = (dataRow[columnName] == null) ? null : Convert.ChangeType(dataRow[columnName], t);
    
    							property.SetValue(returnObject, safeValue, null);
    						}
    					}
    				}
    			}
    		}
    
    		return returnObject;
    	}
    	catch (MissingMethodException)
    	{
    		return null;
    	}
    }
