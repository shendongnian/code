    public class TimeStampedDouble  : IComparable<TimeStampedDouble>
    {
        public TimeStampedDouble(double value)
        {
            Value = value;
            Date = DateTime.Now;
        }
        public double Value { get; private set; }
        public DateTime Date { get; private set; }
        public int CompareTo(TimeStampedDouble other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
