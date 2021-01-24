      List<DateTime> times = new List<DateTime>() {
        new DateTime(2019, 01, 01, 17, 00, 00),
        new DateTime(2019, 01, 01, 18, 45, 00),
        new DateTime(2019, 01, 01, 19, 00, 00),
        new DateTime(2019, 01, 01, 19, 30, 00),
        new DateTime(2019, 01, 01, 22, 30, 00),
      };
      DateTime toFind = new DateTime(2019, 5, 8, 18, 20, 0);
      var closestTime = times
        .Aggregate((best, item) => Math.Abs((item.TimeOfDay - toFind.TimeOfDay).Ticks) < 
                                   Math.Abs((best.TimeOfDay - toFind.TimeOfDay).Ticks) 
           ? item 
           : best);
