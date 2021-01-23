	public static class CollectionHelper
	{
		public static void RemoveWhere<T>(this IList<T> list, Func<T, bool> selector)
		{
			var itemsToRemove = list.Where(selector).ToList();
			foreach (var item in itemsToRemove)
			{
				list.Remove(item);
			}
		}
		public static void RemoveWhere<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>, bool> selector)
		{
			var itemsToRemove = dictionary.Where(selector).ToList();
			foreach (var item in itemsToRemove)
			{
				dictionary.Remove(item);
			}
		}
	}
