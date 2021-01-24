	void Main()
	{
		Console.WriteLine(DateTime.Now.GetWeekOfMonth());		
	}
	
	public static class MyDateTimeExtensions
	{
		private static GregorianCalendar _calendar = new GregorianCalendar();
		
		public static int GetWeekOfMonth(this DateTime date)
		{
			return 
            	date.GetWeekOfYear()
				- new DateTime(date.Year, date.Month, 1).GetWeekOfYear()
				+ 1;
		}
		
		private static int GetWeekOfYear(this DateTime date)
		{
			return _calendar.GetWeekOfYear(
				date, 
				CalendarWeekRule.FirstDay, 
				DayOfWeek.Sunday);
		}
	}
