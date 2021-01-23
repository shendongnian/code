    public IEnumerable<Tuple<string, int>> GetEnumValuePairs(Type enumType)
    {
    	if(!enumType.IsEnum)
    	{
    		throw new ArgumentException();
    	}
    
    	List<Tuple<string, int>> result = new List<Tuple<string, int>>();
    
    	foreach (var value in Enum.GetValues(enumType))
    	{
    		string fieldName = Enum.GetName(enumType, value);
    
    		FieldInfo fieldInfo = enumType.GetField(fieldName);
    		var descAttribute = fieldInfo.GetCustomAttributes(false).Where(a => a is DescriptionAttribute).Cast<DescriptionAttribute>().FirstOrDefault();
    
    		// ideally check if descAttribute is null here
    		result.Add(Tuple.Create(descAttribute.Description, (int)value));
    	}
    
    	return result;
    }
