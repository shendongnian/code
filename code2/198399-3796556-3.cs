	public IEnumerable<int> SortToMiddle(IEnumerable<int> input)
	{
		var sorted = new List<int>(input);
		sorted.Sort();
		var firstHalf = new List<int>();
		var secondHalf = new List<int>();
		var sendToFirst = true;
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
        //to get the highest values on the outside just reverse 
        //the first list instead of the second
		secondHalf.Reverse();
		return firstHalf.Concat(secondHalf);
	}
