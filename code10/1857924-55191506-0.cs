	public static List<T> ConvertMysteriousObjectToList<T>(object input)
	{
		var enumerable = input as IEnumerable;
		if (enumerable == null) throw new InvalidOperationException("The object is not convertible to a list.");
		return enumerable.Cast<T>().ToList();
	}
