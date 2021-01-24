csharp
		public static TResult Deserialize<TResult>(BufferedStreamReader inputStream) where TResult : class
		{
			if (inputStream.EndOfStream) return default;
			if (typeof(TResult).IsEnumerable()) //arrays, lists, etc are a special cases
			{
				Type itemType = typeof(TResult).GetItemType();
				MethodInfo methodInfo = typeof(FixedWidthSerializer)
					.GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
					.FirstOrDefault(m => m.Name == "DeserializeEnumerable")
					.MakeGenericMethod(new[] { typeof(TResult), itemType });
				return methodInfo.Invoke(null, new[] { inputStream }) as TResult;
			}
            ...
         }
		private static TResult DeserializeEnumerable<TResult, TType>(BufferedStreamReader inputStream) //ignore the IDE, this is being called through reflection
			where TResult : class
			where TType : class
		{
			var list = new List<TType>();
			TType item;
			while ((item = Deserialize<TType>(inputStream)) != null)
				list.Add(item);
			if (typeof(TResult).IsArray)
				return list.ToArray<TType>() as TResult;
			return list.AsEnumerable<TType>() as TResult;
		}
