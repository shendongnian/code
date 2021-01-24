	public static class DateUtils
	{
		public static List<DateTime> GetWeekdayInRange(this DateTime from, DateTime to, DayOfWeek day)
		{
			const int daysInWeek = 7;
			var result = new List<DateTime>();
			var daysToAdd = ((int)day - (int)from.DayOfWeek + daysInWeek) % daysInWeek;
			
			do
			{
				from = from.AddDays(daysToAdd);
				result.Add(from);
				daysToAdd = daysInWeek;
			} while (from < to);
			return result;
		}
	}
