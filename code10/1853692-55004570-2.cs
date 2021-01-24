	static string ZigZag(string input, int level)
	{
		var indexMap = new List<int>();
		var tempIndex = 0; bool isIncreasing = true;
		for (int i = 0; i < input.Length; i++)
		{
			indexMap.Add(tempIndex);
			if (isIncreasing)
			{ // Zig
				tempIndex++;
			}
			else
			{  // Zag
				tempIndex--;
			}
			if (tempIndex == level - 1)
			{
				isIncreasing = false;
			}
			if (tempIndex == 0)
			{
				isIncreasing = true;
			}
		}
		var result =
				input.Select((c, i) => new { Char = c, Index = indexMap[i] })
					.GroupBy(x => x.Index)
					.OrderBy(g => g.Key)
					.SelectMany(x => x.Select(y => y.Char))
					.ToArray();
		return new string(result);
	}
