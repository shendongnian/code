      string source = @"0812";
      int SystemYear = 19;
      // Parsed date, note, that year is DateTime.Now.Year, not required SystemYear
      DateTime date = DateTime.ParseExact(source, "MMdd", CultureInfo.InvariantCulture);
      date = new DateTime(
        CultureInfo.InvariantCulture.Calendar.ToFourDigitYear(SystemYear), // SystemYear
        date.Month,                                                        // same Month
        date.Day);                                                         // same Day
      // "12-AUG-19"
      string result = date.ToString("dd'-'MMM'-'yy", CultureInfo.InvariantCulture).ToUpper();
