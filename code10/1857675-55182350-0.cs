	public static List<Time> CreateListOfTimes()
	{	
		return Enumerable.Range(8, 8).Select(i => new Times
		{
			StartTime = i,
			EndTime = i + 1
		}).ToList();
	}
