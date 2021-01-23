            static int LeapYearsBetween(int start, int end)
            {
                System.Diagnostics.Debug.Assert(start < end);
                return LeapYearsBefore(end) - LeapYearsBefore(start + 1);
            }
    
            static int LeapYearsBefore(int year)
            {
                System.Diagnostics.Debug.Assert(year > 0);
                year--;
                return (year / 4) - (year / 100) + (year / 400);
            }
