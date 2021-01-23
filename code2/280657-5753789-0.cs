	public static T MaxItem<T>(this IEnumerable<T> list, Func<T, int> selector) {
		var enumerator = list.GetEnumerator();
		
		if (!enumerator.MoveNext()) {
			// Return null/default on an empty list. Could choose to throw instead.
			return default(T);
		}
		T maxItem = enumerator.Current;
		int maxValue = selector(maxItem);
		
		while (enumerator.MoveNext()) {
			var item = enumerator.Current;
			var value = selector(item);
			
			if (value > maxValue) {
				maxValue = value;
				maxItem = item;
			}
		}
		
		return maxItem;
	}
