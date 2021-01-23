        static void yourFunction()
        {
            //
            //Some Stuffs
            //
            foreach (var tempItem in TaskList)
            {
                if (DateRange.Contains(tempItem.Date[0]))
                {
                    //Do Task
                }
                else
                {
                    //Do Task
                }
            }
            //
            //Some Stuffs
            //
        }
        public static IEnumerable<DateTime> DateRange
        {
            get
            {
                for (DateTime day = startDate; day < EndDate; day = day.AddDays(1))
                {
                    yield return day;
                }
            }
        } 
