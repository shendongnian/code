    // implement this
    public class DateTimeComparer : IComparer<DateTime>
    {
        public int Compare(DateTime x, DateTime y)
        {
            return x.Year == y.Year && x.Month == y.Month ? 0 : x.CompareTo(y);
        }
    }
    // use it like this
    UniqueMonthYears = CompleteListOfDates.Distinct(new DateTimeComparer()).ToList();
