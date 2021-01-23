    DateTime expectedDate = vacationDateToCheck.AddDays(1);
    if (vacationDateToCheck.DayOfWeek == DayOfWeek.Friday)
      expectedDate = expectedDate.AddDays(2);
    DateTime startDate = vacationDateToCheck;
    DateTime endDate = vacationDateToCheck;
    for (int j = i + 1; i < dates.Length; i++) {
      if (dates[i] == expectedDate) {
        endDate = dates[i];
        expectedDate = dates[i].AddDays(1);
        if (dates[i].DayOfWeek == DayOfWeek.Friday)
          expectedDate = expectedDate.AddDays(2);
      } 
      else 
      {
        break;
      }
    }
