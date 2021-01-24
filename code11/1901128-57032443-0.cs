	public static CopticDate ToCopticDate(this DateTime date)
	{
		var localDateTime = LocalDateTime.FromDateTime(date, CalendarSystem.Gregorian)
            .WithCalendar(CalendarSystem.Coptic);
		return new CopticDate
		{
			Day = localDateTime.Day,
			Month = (CopticMonth)localDateTime.Month,
			Year = localDateTime.Year
		};
	}
