	public static class Extensions
	{
		public static List<T> ReplaceAllIf<T>(this List<T> list, bool condition, T valueToFind, T replacement)
		{
			return condition ? list.ReplaceAll(valueToFind, replacement) : list;
		}
		public static List<T> ReplaceAll<T>(this List<T> list, T valueToFind, T replacement)
		{
			return list.Select(x => x.Equals(valueToFind) ? replacement : x).ToList();
		}
	}
