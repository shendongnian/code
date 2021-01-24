	public static class Ex
	{
		public static double SumIf<T>(this IEnumerable<T> source,
		  	Func<T, bool> filter,
		  	Func<T, double> selector)
		{
			return source.Where(x => filter(x)).Sum(selector);
		}
	}
