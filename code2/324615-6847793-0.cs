    public class FuzzyDate
	{
		private int Year;
		private int? Month;
		private int? Day;
		public FuzzyDate(int Year, int? Month, int? Day)
		{
			this.Year = Year;
			this.Month = Month;
			this.Day = Day;
		}
		public DateType DateType
		{
			get
			{
				if(Day.HasValue && Month.HasValue)
				{
					return DateType.DayMonthYear;
				}
				else if(Month.HasValue)
				{
					return DateType.MonthYear;
				}
				else
				{
					return DateType.Year;
				}
			}
		}
		public DateTime Date
		{
			get
			{
				return new DateTime(Year, Month.GetValueOrDefault(1), Day.GetValueOrDefault(1));
			}
		}
	}
	public enum DateType
	{
		DayMonthYear,
		MonthYear,
		Year
	}
