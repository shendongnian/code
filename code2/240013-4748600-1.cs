      DateTime date1 = new DateTime(1973, 07, 20);
      DateTime date2 = new DateTime(2010, 01, 10);
      // Swap them if one is bigger than the other
      if (date2 < date1)
      {
        DateTime date3 = date2;
        date2 = date1;
        date1 = date3;
      }
      // Now date2 >= date1.
      TimeSpan ts = date2 - date1;
      // Total days
      Console.WriteLine(ts.TotalDays);
      // Total years
      int years = date2.Year - date1.Year;
      int months = 0;
      // Total monts
      if (date2.Month < date1.Month)
      {
        // example: March 2010 (3) and January 2011 (1); this should be 10 monts
        // 12 - 3 + 1 = 10
        // Take the 12 months of a year into account
        months = 12 - date1.Month + date2.Month;
      }
      else
      {
        months = date2.Month - date1.Month;
      }
      Console.WriteLine("Years: {0}, Months: {1}", years, months);
