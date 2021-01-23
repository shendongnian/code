		private static IEnumerable<DateTime> ByMonths(DateTime startDate, DateTime endDate)
		{
		  DateTime cur = startDate;
		  for(int i = 0; cur <= endDate; cur = startDate.AddMonths(++i))
		  {
			 yield return cur;
		  }
		}
