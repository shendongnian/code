    public FuzzyDate(int year)
    {
       Date = new DateTime(year,1,1); // 1 Jan yy
       Type = DateType.Year;
    }
    public FuzzyDate(int year, int month)
    {
       Date = new DateTime(year, month, 1); // 1 mm yy
       Type = DateType.MonthYear;
    }
    public FuzzyDate(int year, int month, int day)
    {
       Date = new DateTime(year, month, day); // dd mm yy
       Type = DateType.DayMonthYear;
    }
