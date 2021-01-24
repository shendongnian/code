    var jobs = new List<Job>()
    {
    new Job { Level = 1, Date = new DateTime(2019, 1, 1), Quantity = 111 },
    new Job { Level = 1, Date = new DateTime(2019, 1, 20), Quantity = 222 },
    new Job { Level = 2, Date = new DateTime(2019, 2, 1), Quantity = 333 },
    new Job { Level = 2, Date = new DateTime(2019, 2, 20), Quantity = 444 }
    };
    
    var solutions = new List<Solution>()
    {
    new Solution { Level = 1, Date = new DateTime(2019, 2, 1), Quantity = 555 },
    new Solution { Level = 2, Date = new DateTime(2019, 2, 20), Quantity = 666 },
    new Solution { Level = 1, Date = new DateTime(2019, 1, 1), Quantity = 777 },
    new Solution { Level = 2, Date = new DateTime(2019, 1, 20), Quantity = 888 }
    };
  
    foreach (var sol in solutions)
    {
      var jb = new Job();
      jb.Level = sol.Level;
      jb.Date = sol.Date ;
      jb.Quantity= sol.Quantity;
       jobs.Add(jb);
    }
     var result = Jobs.GroupBy(x=> new { x.Level, x.Date}).Select(x=> new 
     {
      level = x.Key.Level,
      date = x.Key.Date,
      sumQ = x.Sum(y => y.Quantity )
     });
