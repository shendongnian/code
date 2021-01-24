	public static int Counter()
	{
		Type type = typeof(T);
		foreach (var property in type.GetProperties())
		{
			Console.WriteLine(property.Name);
			if (property.PropertyType.IsArray)
			{
				var array = property.GetValue(null, null) as Array;
				Console.WriteLine(array.Length);
			}
		}
		return _counter;
	}
