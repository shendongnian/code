        private List<DurationModel> GetDurationList(DateTime StartDate, DateTime EndDate)
        {
            List<DurationModel> DurationList = new List<DurationModel>();
            // Start from Start Date, get Next Sunday.
            DateTime FirstSundayAfterStartDate = StartDate.AddDays(7 - (int)StartDate.DayOfWeek);
            // Add First Segment
            DurationList.Add(new DurationModel(StartDate, FirstSundayAfterStartDate));
            DateTime NextMonday = FirstSundayAfterStartDate.AddDays(1);
            DateTime NextSunday = FirstSundayAfterStartDate.AddDays(7);
            // Add intermediate segments
            while (NextSunday <= EndDate)
            {
                DurationList.Add(new DurationModel(NextMonday, NextSunday));
                NextMonday = NextSunday.AddDays(1);
                NextSunday = NextSunday.AddDays(7);
            }
            // Add Last Segment
            DurationList.Add(new DurationModel(NextMonday, EndDate));
            return DurationList;
        }
