    class sm
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int Interval { get; set; }
        public bool InDateRange ( DateTime start, DateTime end ) => start <= Date && Date <= end;
        public bool InIntervalRange ( int start, int end ) => start <= Interval && Interval <= end;
        public static int GetSum ( IEnumerable<sm> sms, int intervalStart, int intervalEnd, DateTime dateStart, DateTime dateEnd ) => sms
            .Where ( sm => sm.InDateRange ( dateStart, dateEnd ) && sm.InIntervalRange ( intervalStart, intervalEnd ) )
            .Sum ( sm => sm.value );
    }
