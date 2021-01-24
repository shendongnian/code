	public static TResult Deserialize<TResult>(StreamReader inputStream) where TResult : class
	{
		if (inputStream.EndOfStream) return default(TResult);
		if (typeof(TResult).IsEnumerable())
		{
			Type itemType = typeof(TResult).GetItemType();
			var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));
			
			MethodInfo addMethod = list
									.GetType()
									.GetMethod("Add");
									
			MethodInfo methodInfo = typeof(SimpleFixedWidthSerializer)
										.GetMethod("Deserialize", new[] { typeof(StreamReader) })
										.MakeGenericMethod(new[] { itemType });
			object item = null;
			do
			{
				item = methodInfo.Invoke(null, new[] { inputStream });
				if (item != null)
					addMethod.Invoke(list, new[] { item });
			} while (item != null);
			
			MethodInfo toArray = list
									.GetType()
									.GetMethod("ToArray");
									
			if (typeof(TResult).IsArray)
				return toArray.Invoke(list, null) as TResult;
			return ((IEnumerable)list) as TResult;			
		}
        ...
	}
