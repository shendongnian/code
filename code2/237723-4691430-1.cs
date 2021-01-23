    var list = new List<DateTime>
        {
            new DateTime(1231223423433132),
            new DateTime(13223123132),
            new DateTime(12333123132),
            new DateTime(123345123132),
            DateTime.Now,
            new DateTime(5634534553)
        };
    var allYearMonthes = list.Select(o => 
                                 Eumerable.Range(1, 12)
                                     .Select(q => new { o.Year, Month = q }))
                              .SelectMany(o => o);
    var enumerable = allYearMonthes.Except(list.Select(o => new { o.Year, o.Month }));
    var dateTimes = enumerable.Select(o => new DateTime(o.Year, o.Month, 1));
