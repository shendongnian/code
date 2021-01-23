        var data = new[]
                   {
                       new  { Date = DateTime.Now.AddDays(-5), Duration = 3.56 },
                       new  { Date = DateTime.Now.AddDays(-3), Duration = 3.436 },
                       new  { Date = DateTime.Now.AddDays(-1), Duration = 1.56 },
                   };
        Func<DateTime, DateTime, IEnumerable<DateTime>> range = (DateTime from, DateTime to) =>
                    {
                        List<DateTime> dates = new List<DateTime>();
                        from = from.Date;
                        to = to.Date;
                        while (from <= to)
                        {
                            dates.Add(from);
                            from = from.AddDays(1);
                        }
                        return dates;
                    };
        var result = range(data.Min(e => e.Date.Date), data.Max(e => e.Date.Date))
            .Join(data, e => e.Date.Date, e => e.Date, (d, x) => new {
                                                                         Date = d,
                                                                         Duration = x == null
                                                                             ? 0.0
                                                                             : x.Duration
                                                                     });
        
