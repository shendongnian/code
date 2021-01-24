	/// <summary>
	/// Constructs a tuple our of an array of arguments
	/// </summary>
	/// <typeparam name="T">The type of argument.</typeparam>
	/// <param name="values">The values.</param>
	/// <returns></returns>
	public static object ConstructTuple<T>(params T[] values)
	{
		Type genericType = Type.GetType("System.Tuple`" + values.Length);
		Type[] typeArgs = values.Select(_ => typeof(T)).ToArray();
		Type specificType = genericType.MakeGenericType(typeArgs);
		object[] constructorArguments = values.Cast<object>().ToArray();
		return Activator.CreateInstance(specificType, constructorArguments);
	}
	/// <summary>
	/// Flattens a tupple into an enumeration using reflection.
	/// </summary>
	/// <typeparam name="T">The type of objects the nested tuple contains.</typeparam>
	/// <param name="tuple">The tuple to flatten.</param>
	/// <returns></returns>
	public static IEnumerable<T> FlattenTupple<T>(object tuple)
	{            
		List<T> items = new List<T>();
		var type = tuple.GetType();
		if (type.GetInterface("ITuple") == null)
			throw new ArgumentException("This is not a tuple!");
		foreach (var property in type.GetProperties())
		{
			var value = property.GetValue(tuple);
			if (property.PropertyType.GetInterface("ITuple") != null)
			{                    
				var subItems = FlattenTupple<T>(value);
				items.AddRange(subItems);
			}
			else
			{
				items.Add((T)value);
			}
		}
		return items;
	}
