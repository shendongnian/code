	public static Func<T, bool> ContainsPredicate2<T>(string memberName, string searchValue)
	{
		var prop = typeof(T).GetProperty(memberName);
		Func<T, bool> func = (T obj2) =>
			prop.GetValue(obj2).ToString().ToLower().Contains(searchValue);
		return func;
	}
