	public static CopticDate ToCopticDate(this DateTime date)
	{
		var localDate = LocalDate.FromDateTime(date, CalendarSystem.Gregorian)
                                 .WithCalendar(CalendarSystem.Coptic);
		return new CopticDate
		{
			Day = localDate.Day,
			Month = (CopticMonth)localDate.Month,
			Year = localDate.Year
		};
	}
