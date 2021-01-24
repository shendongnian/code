	public static List<TProperty> GetAllPropertyValuesOfType<TProperty>(this object obj)
	{
		return obj.GetType()
			.GetProperties()
			.Where(prop => prop.PropertyType == typeof(TProperty))
			.Select(pi => (TProperty)pi.GetValue(obj))
			.ToList();
	}
