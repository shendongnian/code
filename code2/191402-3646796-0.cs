		public static string Join<T>(this IEnumerable<T> items, string delimiter)
		{
			var result = new StringBuilder();
			if (items != null && items.Any())
			{
				delimiter = delimiter ?? "";
				foreach (var item in items)
				{
					result.Append(item);
					result.Append(delimiter);
				}
				result.Length = result.Length - delimiter.Length;
			}
			return result.ToString();
		}
