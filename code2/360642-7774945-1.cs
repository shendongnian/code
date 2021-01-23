    var random = new Random();
    var weeks = new List<Week>();
    for (int i=0; i<1000000; i++)
    {
        weeks.Add(
          new Week {
              WeekStartDate = DateTime.Now.Date.AddDays(7 * random.Next(0, 100))
          });
    }
    var parallelCollectionByWeek =
        (from item in weeks.AsParallel()
         group item by item.WeekStartDate into weekGroups
         select new
         {
           p1 = weekGroups.First().WeekStartDate,
           p2 = weekGroups.Key,
         }).ToList();
