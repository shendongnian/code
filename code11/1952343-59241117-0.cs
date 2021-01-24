	public static List<DateTime> FindFirstStreak(List<DateTime> dates)
	{
		if (dates.Count == 1)
			return dates;
		var ret = new List<DateTime>();
		for (int i = 0; i < dates.Count - 1; i++)
		{
			var today = dates[i];
			var tom = today.AddDays(1);
			var next = dates[i + 1];
			
			if (next == tom)
			{
				if (ret.Count == 0) ret.Add(today);
				ret.Add(tom);
			}
			else
			{
				if (ret.Count > 0)
				{
					// check if streak has ended
					if (next != tom)
						return ret;
					// optional: add ret, to result List<List<DateTime>> 
					// and reset ret = new List<DateTime>(), to get all streaks
				}
			}
		}
		return ret;
	}
