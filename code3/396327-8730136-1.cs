    // implement this
    public class DateTimeComparer : IEqualityComparer<DateTime>
    {
        public int Equals(DateTime x, DateTime y)
        {
            return x.Year == y.Year && x.Month == y.Month;
        }
    }
    // use it like this
    UniqueMonthYears = CompleteListOfDates.Distinct(new DateTimeComparer()).ToList();
