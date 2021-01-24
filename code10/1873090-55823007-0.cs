	public static DateTime GetNextDateTime(DateTime now, DayOfWeek targetDay, TimeSpan targetTime)
	{
		DateTime target = now.Date.Add(targetTime);
		while (target < now || target.DayOfWeek != targetDay)
		{
			target = target.AddDays(1.0);
		}
		return target;
	}
