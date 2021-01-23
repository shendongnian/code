	public static class EnumerableExtensionsEx
	{
		public static AutoCompleteStringCollection ToAutoCompleteStringCollection(
			this IEnumerable<string> enumerable)
		{
			if(enumerable == null) throw new ArgumentNullException("enumerable");
			var autoComplete = new AutoCompleteStringCollection();
			foreach(var item in enumerable) autoComplete.Add(item);
			return autoComplete;
		}
	}
