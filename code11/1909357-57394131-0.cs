    List<DateTime> dates = new List<DateTime>(){
        new DateTime(2019,1,1,10,0,0),
        new DateTime(2019,1,1,12,0,0),
        new DateTime(2019,1,1,13,0,0),
        new DateTime(2019,1,1,14,0,0),
        new DateTime(2019,1,2,10,0,0),
        new DateTime(2019,1,2,12,0,0),
        new DateTime(2019,1,2,14,0,0),
        new DateTime(2019,1,3,10,0,0),
        new DateTime(2019,1,3,11,0,0),
        new DateTime(2019,1,3,12,0,0)
       };
      
      var result = dates.GroupBy(d => d.Date)
        .Select(bla => new {
          Date = bla.First().Date,
          Hours = bla.Last() - bla.First() }).ToList();
