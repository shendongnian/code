	public static class ValidationExtensions
	{
		public static ICollection<string> ValidProperties<TObject, TValue>(this IEnumerable<TObject> items, Predicate<TValue> isValid)
		{
			var properties = typeof(TObject).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => typeof(TValue).IsAssignableFrom(p.PropertyType))
				.Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && p.GetGetMethod() != null)
				.ToList();
			
			var list = new List<string>();
			foreach (var p in properties)
				foreach (var i in items)
					if (isValid((TValue)p.GetValue(i)))
					{
						list.Add(p.Name);
						break;
					}
			return list;
		}
	}
