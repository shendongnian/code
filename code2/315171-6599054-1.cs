	public static class BindingListExtensions
	{
		public static void RemoveAll<T>(this BindingList<T> list, Func<T, bool> predicate)
		{
			// first check predicates -- uses System.Linq
			var toRemove = list.Where(predicate).ToList();
			// then loop and remove after
			foreach (var item in toRemove)
			{
				list.Remove(item);
			}
		}
	}
