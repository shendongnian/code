    // implement this
    public class DateTimeComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Year == y.Year && x.Month == y.Month;
        }
        public int GetHashCode(DateTime obj)
        {
            return obj.Year * 100 + obj.Month;
        }
    }
    // use it like this
    UniqueMonthYears = CompleteListOfDates.Distinct(new DateTimeComparer()).ToList();
