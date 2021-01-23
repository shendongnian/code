		public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue)
		{
			IEnumerator<T> enumerator = source.GetEnumerator();
			using(enumerator)
			{
				if (enumerator.MoveNext())
					return enumerator.Current;
				else
					return defaultValue;
			}
		}
		public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
		{
			IEnumerator<T> enumerator = source.Where(predicate).GetEnumerator();
			using(enumerator)
			{
				if (enumerator.MoveNext())
					return enumerator.Current;
				else
					return defaultValue;
			}
		}
