	public static IEnumerable<int> GetDiff(int start, int end)
	{
		while (true)
		{
			if (start >= end)
				yield break;
			yield return start;
			start++;
		}
	}
