    public static IEnumerable<T> Flatten<T>(this IEnumerable<T> hierarchy, Func<T, IEnumerable<T>> lambda)
		{
			var result = new List<T>();
			foreach (var item in hierarchy)
			{
				result.AddRange(Flatten(lambda(item), lambda));
				if (!result.Contains(item))
					result.Add(item);
			}
			return result;
		}
