    public List<DateTime> ThirdSundayOfEachMonth( DateTime startdate, DateTime enddate )
    {
      List<DateTime> result = new List<DateTime>();
      int sundaymonthcount = 0;
      for( DateTime traverser = new DateTime(startdate.Year, startdate.Month, 1); traverser <= enddate; traverser = traverser.AddDays(1) ){
        if( traverser.DayOfWeek == DayOfWeek.Sunday ) sundaymonthcount++;
        if( sundaymonthcount == 3 && traverser > startdate ){
          result.Add(traverser);
          sundaymonthcount = 0;
          traverser = new DateTime( traverser.Year, traverser.Month, 1 ).AddMonths(1);
        }
      }
    return result;
    }
