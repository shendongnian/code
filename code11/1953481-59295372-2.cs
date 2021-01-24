	public static class ValidationExtensions
	{
		public static ICollection<string> ValidProperties<TObject, TValue>(this IEnumerable<TObject> items, Predicate<TValue> isValid)
		{
			var properties = typeof(TObject).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => typeof(TValue).IsAssignableFrom(p.PropertyType))
				.Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && p.GetGetMethod() != null)
				.ToList();
			var set = new HashSet<string>();
			
			foreach (var i in items) // Only iterate through the items once.
				foreach (var p in properties)
				{
					if (set.Contains(p.Name)) // Do not call GetValue() if not necessary, it's expensive.
						continue;
					if (isValid((TValue)p.GetValue(i)))
						set.Add(p.Name);
				}
					
			// Return properties in order
			return properties.Select(p => p.Name).Where(n => set.Contains(n)).ToList();
		}
	}
