	static IEnumerable<IEnumerable<Item>> GroupUp(IEnumerable<Item> input)
	{
		var sorted = input.OrderBy( item => int.Parse(item.Amount) ).GetEnumerator();
		int lastValue = int.MinValue;
		var list = new List<Item>();
		while (sorted.MoveNext())
		{
			var current = sorted.Current;
			var currentAmount = int.Parse(current.Amount);
			var gap = currentAmount - lastValue;
			if (gap < 3)
			{
				list.Add(current);
			}
			else
			{
				if (list.Count != 0) yield return list;
				list = new List<Item>();
				list.Add(current);
			}
			lastValue = currentAmount;
		}
		if (list.Count != 0) yield return list;
	}
