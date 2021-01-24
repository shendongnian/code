    class sm
    {
        public int value;
        public DateTime date;
        public int interval;
        public bool InDateRange ( DateTime start, DateTime end ) => start <= date && date <= end;
        public bool InIntervalRange ( int start, int end ) => start <= interval && interval <= end;
        public static int GetSum ( IEnumerable<sm> sms, int intervalStart, int intervalEnd, DateTime dateStart, DateTime dateEnd ) => sms
            .Where ( sm => sm.InDateRange ( dateStart, dateEnd ) && sm.InIntervalRange ( intervalStart, intervalEnd ) )
            .Sum ( sm => sm.value );
    }
