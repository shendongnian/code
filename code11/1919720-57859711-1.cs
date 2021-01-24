    enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
    
    class CalendarBase
    {
            public Dictionary<string, Button[]> Month = new Dictionary<string, Button[]>()
            {
                {Months.January, new Button[32] },
                {Months.February, new Button[32] },
                {Months.March, new Button[32] },
                {Months.April, new Button[32] },
                {Months.May, new Button[32] },
                {Months.June, new Button[32] },
                {Months.July, new Button[32] },
                {Months.August, new Button[32] },
                {Months.September, new Button[32] },
                {Months.October, new Button[32] },
                {Months.November, new Button[32] },
                {Months.December, new Button[32] },
            };
    }
    
