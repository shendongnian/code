    var byMonths = GetTotal(123, yourDate, (d, i) => d.AddMonths(i));
    var byDays = GetTotal(456, anotherDate, (d, i) => d.AddDays(i));
    // ...
    IEnumerable<TotalType> GetTotal(
        string id, DateTime lastTotalDate, Func<DateTime, int, DateTime> adder)
    {
        for (int i = 0; adder(lastTotalDate, i + 1) <= DateTime.Now; i++)
        {
            var temp = adder(lastTotalDate, i);
            var totalStartDate = new DateTime(temp.Year, temp.Month, 1);
            var totalEndDate = adder(totalStartDate, 1);
            var total = this.GetTotal(id, totalStartDate, totalEndDate);
            var interval = new TimeInterval(totalStartDate, totalEndDate);
            yield return new TotalType(id, total, interval);
        }
    }
