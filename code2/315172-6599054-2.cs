	public static class BindingListExtensions
	{
		public static void RemoveAll<T>(this BindingList<T> list, Func<T, bool> predicate)
		{
			// first check predicates -- uses System.Linq
			// could collapse into the foreach, but still must use 
			// ToList() or ToArray() to avoid deferred execution                       
			var toRemove = list.Where(predicate).ToList();
			// then loop and remove after
			foreach (var item in toRemove)
			{
				list.Remove(item);
			}
		}
	}
