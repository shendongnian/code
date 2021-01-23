		public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue)
		{
			using (IEnumerator<T> enumerator = source.GetEnumerator())
			{
				if (enumerator.MoveNext())
					return enumerator.Current;
				else
					return defaultValue;
			}
		}
		public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
		{
			using (IEnumerator<T> enumerator = source.Where(predicate).GetEnumerator())
			{
				if (enumerator.MoveNext())
					return enumerator.Current;
				else
					return defaultValue;
			}
		}
