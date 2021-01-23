    public class DateRange
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    
        public DateRange(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }
    }
