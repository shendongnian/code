    public static int GetWeeksInYear(int year) {
      if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
        throw new ArgumentOutOfRangeException(nameof(year));
      var dw = new DateTime(year, 1, 1).DayOfWeek;
      return (dw == DayOfWeek.Thursday) || 
             (dw == DayOfWeek.Wednesday) && DateTime.IsLeapYear(year) 
        ? 53
        : 52;
    }
