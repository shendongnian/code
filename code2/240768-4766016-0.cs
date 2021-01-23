    static IEnumerable<DateTime> monthsBetween(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate.Year - startDate.Year) * 12 + (endDate.Month - startDate.Month + 1))
                             .Select(m => new DateTime(startDate.Year, startDate.Month, 1).AddMonths(m));
        }
