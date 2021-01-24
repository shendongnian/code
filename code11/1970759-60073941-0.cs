    public class TimePeriod
    {
      public DateTime Start { get; set; }
      public DateTime End { get; set; }
   
      public TimePeriod(DateTime start, DateTime end)
      {
        //TODO: Make sure startDate is lower than EndDate
        Start = start;
        End = end;
      }
   
      public bool Overlaps(TimePeriod tp)
      {
        // it's enough for one's period start or end to fall between the other's start and end to overlap
        if ((Start > tp.Start && Start < tp.End ) ||
          (End > tp.Start && End < tp.End) ||
          (tp.Start > Start && tp.Start < End) ||
          (tp.End > Start && tp.End < End) )
          return true;
        else
          return false;
      }
    }
	
