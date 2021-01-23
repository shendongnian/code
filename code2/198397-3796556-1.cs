	public IEnumerable<int> SortToMiddle(IEnumerable<int> input)
	{
		var sendToFirst = true;
		var sorted = new List<int>(input);
		sorted.Sort();
		var firstHalf = new List<int>();
		var secondHalf = new List<int>();
		foreach (var current in sorted)
		{
			if (sendToFirst)
			{
				firstHalf.Add(current);
			}
			else
			{
				secondHalf.Add(current);
			}
			sendToFirst = !sendToFirst;
		}
		secondHalf.Reverse();
		return firstHalf.Concat(secondHalf);
	}
