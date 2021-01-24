    public T GetDefaultValue<T>(string propertyName)
    {
    	var result = typeof(SomeClass).GetProperty(nameof(SomeClass.IsSoundEffects), BindingFlags.Public | BindingFlags.Static)
    								.GetCustomAttribute<DefaultValueAttribute>().DefaultValue;
    	
    	return (T)Convert.ChangeType(result,typeof(T));
    }
