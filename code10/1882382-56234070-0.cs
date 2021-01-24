	public static int GetNextSequenceNum(this IEnumerable<int> sequence)
	{
		var nums = sequence.OrderBy(i => i).ToList();
		var max = nums[nums.Count - 1];
		return Enumerable.Range(0, max + 1)
			.GroupJoin(nums, i => i, i => i, (i, found) =>
			{
				var f = found.ToList();
				if (f.Count == 0)
					return i;
				else
					return (int?)null;
			})
			.First(i => i.HasValue)
			.Value;
	}
