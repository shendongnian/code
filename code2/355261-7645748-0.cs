    // The input type
    class DateRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    // Captures details of a transition point
    // along with how many ranges start and end at this point
    class TransitionWithCounts
    {
        public DateTime DateTime { get; set; }
        public int Starts { get; set; }
        public int Finishes { get; set; }
    }
