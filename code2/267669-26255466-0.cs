	void Main()
	{
		DayOfWeek dow = DayOfWeek.Friday;
		int y = 2014;
		int m = 2;
	
		String.Format("First {0}: {1}", new object[] { dow, DateHelper.FirstDayOfWeekInMonth(y, m, dow) }).Dump();
		
		"".Dump();
		
		String.Format("Last {0}: {1}", new object[] { dow, DateHelper.LastDayOfWeekInMonth(y, m, dow) }).Dump();
	
		"".Dump();
		
		for(int i = 1; i <= 6; i++)
			String.Format("{0} #{1}: {2}", new object[] { dow, i, DateHelper.XthDayOfWeekInMonth(y, m, dow, i) }).Dump();
	}
    public class DateHelper
    {
        public static DateTime FirstDayOfWeekInMonth(int year, int month, DayOfWeek day)
        {
            DateTime res = new DateTime(year, month, 1);
            int offset = -(res.DayOfWeek - day);
            if (offset < 0)
                offset += 7;
            res = res.AddDays(offset);
            return res;
        }
        public static DateTime LastDayOfWeekInMonth(int year, int month, DayOfWeek day)
        {
            DateTime res = FirstDayOfWeekInMonth(year, month + 1, day);
            res = res.AddDays(-7);
            return res;
        }
        public static DateTime XthDayOfWeekInMonth(int year, int month, DayOfWeek day, int week)
        {
            DateTime res = DateTime.MinValue;
            if (week > 0)
            {
                res = FirstDayOfWeekInMonth(year, month, day);
                if (week > 1)
                    res = res.AddDays((week - 1) * 7);
                res = res.Year == year && res.Month == month ? res : DateTime.MinValue;
            }
            return res;
        }
    }
