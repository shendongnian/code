    // Iterate through the current month and add all Wednesdays to the 
    // SelectedDates collection of the Calendar control.
    for (int i = 1; i <= System.DateTime.DaysInMonth(current_year, current_month); i++)
    {
       DateTime currentDate = new DateTime(current_year, current_month, i);
       if (currentDate.DayOfWeek == DayOfWeek.Wednesday)
       {
         DisplayCalendar.SelectedDates.Add(currentDate);
       }
    }
