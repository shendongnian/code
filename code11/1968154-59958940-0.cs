    public class Result
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Value { get; set; }
        public int IntervalStart { get; set; }
        public int Interval { get; set; } = 4;
        public override string ToString()
        {
            return $"{Value} for range {StartDate.ToShortDateString()} to " +
                $"{EndDate.ToShortDateString()} and interval " + 
                $"{IntervalStart}-{IntervalStart + Interval}";
        }
    }
