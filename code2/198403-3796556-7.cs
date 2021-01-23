	public static IEnumerable<T> SortToMiddle<T, TU>(IEnumerable<T> input, Func<T, TU> getSortKey)
	{
		var sendToFirst = true;
		var sorted = new SortedList<TU, T>(input.ToDictionary(getSortKey, t => t));
		var firstHalf = new SortedList<TU, T>();
		var secondHalf = new SortedList<TU, T>();
		foreach (var current in sorted)
		{
			if (sendToFirst)
			{
				firstHalf.Add(current.Key, current.Value);
			}
			else
			{
				secondHalf.Add(current.Key, current.Value);
			}
			sendToFirst = !sendToFirst;
		}
		//to get the highest values on the outside just reverse 
		//the first list instead of the second
		secondHalf.Reverse();
		return(firstHalf.Concat(secondHalf)).Select(kvp => kvp.Value);
	}
