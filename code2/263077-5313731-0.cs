    public class Record
    {
      public int Group {get;set;}
      public int TimePoint {get;set;}
      public int Value {get;set;}
    }
    
    var groupAverage = from r in records
                       group r by new { r.Group, r.TimePoint } into groups
                       select new
                              {
                                Group = groups.Key.Group,
                                TimePoint = groups.Key.TimePoint,
                                AverageValue = groups.Average(rec => rec.Value)
                              };
