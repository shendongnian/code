    public class DateTimeSpan
    {
      private DateTimeSpan() { }
    
      private DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
      {
        Years = years;
        Months = months;
        Days = days;
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Milliseconds = milliseconds;
      }
    
      public int Years { get; private set; } = 0;
      public int Months { get; private set; } = 0;
      public int Days { get; private set; } = 0;
      public int Hours { get; private set; } = 0;
      public int Minutes { get; private set; } = 0;
      public int Seconds { get; private set; } = 0;
      public int Milliseconds { get; private set; } = 0;
    
      public static DateTimeSpan CompareDates(DateTime StartDate, DateTime EndDate)
      {
        if (StartDate.Equals(EndDate)) return new DateTimeSpan();
        DateTimeSpan R = new DateTimeSpan();
        bool Later;
        if (Later = StartDate > EndDate)
        {
          DateTime D = StartDate;
          StartDate = EndDate;
          EndDate = D;
        }
    
        // Calculate Date Stuff
        for (DateTime D = StartDate.AddYears(1); D < EndDate; D = D.AddYears(1), R.Years++) ;
        if (R.Years > 0) StartDate = StartDate.AddYears(R.Years);
        for (DateTime D = StartDate.AddMonths(1); D < EndDate; D = D.AddMonths(1), R.Months++) ;
        if (R.Months > 0) StartDate = StartDate.AddMonths(R.Months);
        for (DateTime D = StartDate.AddDays(1); D < EndDate; D = D.AddDays(1), R.Days++) ;
        if (R.Days > 0) StartDate = StartDate.AddDays(R.Days);
    
        // Calculate Time Stuff
        TimeSpan T1 = EndDate - StartDate;
        R.Hours = T1.Hours;
        R.Minutes = T1.Minutes;
        R.Seconds = T1.Seconds;
        R.Milliseconds = T1.Milliseconds;
    
        // Return answer. Negate values if the Start Date was later than the End Date
        if (Later)
          return new DateTimeSpan(-R.Years, -R.Months, -R.Days, -R.Hours, -R.Minutes, -R.Seconds, -R.Milliseconds);
        return R;
      }
    }
