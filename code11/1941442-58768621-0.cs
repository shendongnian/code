    public static T FromExpando<T>(ExpandoObject expando) where T : class, new()
    {
        if (expando == null) return null;
        var properties = typeof(T)
            .GetProperties()
            .Where(pi => pi.CanWrite && !pi.GetIndexParameters().Any())
            .ToDictionary(pi => pi.Name.ToLower());
        T obj = new T();
        foreach (var kvp in expando)
        {
			var name = kvp.Key.ToLower().Replace("_", "");
			var val = kvp.Value;
			if (val != null &&
				properties.TryGetValue(name, out PropertyInfo prop) &&
				prop.PropertyType.IsAssignableFrom(val.GetType()))
			{
				prop.SetValue(obj, val);
			}
        }
        return obj;
    }
