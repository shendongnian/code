    IEnumerable<DateTime> FindMissingMonths(DateTime startDate, DateTime endDate, IEnumerable<DateTime> inputs)
    {
        var allMonths = new List<DateTime>();
        for (DateTime d = startDate; d < endDate; d = d.AddMonths(1))
        {
            allMonths.Add(new DateTime(d.Year, d.Month, 1));
        }
        var usedMonths = (from d in inputs
                            select new DateTime(d.Year, d.Month, 1)).Distinct();
        return allMonths.Except(usedMonths);
    }
