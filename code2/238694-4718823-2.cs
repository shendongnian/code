    DateTime start = new DateTime(2010, 1, 1);
    DateTime maxDate = new DateTime(2010, 1, 11);
    List<DateTime> allDays  = Enumerable
                              .Range(0, 1 +(maxDate - start).Days)
                              .Select( d=> start.AddDays(d))
                              .ToList();
