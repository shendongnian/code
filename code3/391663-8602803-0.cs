    public static T ToClass<T>(this IDictionary<string, string> source) where T : class, new()
	{
		Type type = typeof(T);
		T ret = new T();
		foreach (var keyValue in source)
		{
			var propertyInfo = type.GetProperty(keyValue.Key);
			propertyInfo.SetValue(ret, keyValue.Value.ToString().TestParse(propertyInfo.PropertyType), null);
		}
		return ret;
	}
	public static object TestParse(this string value, Type type)
	{
		return TypeDescriptor.GetConverter(type).ConvertFromString(value);
	}
