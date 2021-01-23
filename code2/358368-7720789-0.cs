        private static void CheckTimes()
        {
            DateTime start = DateTime.Parse("2011-10-08 12:30:00");
            DateTime end = DateTime.Parse("2011-10-10 15:00:00");
            // variable to use for bound checking (Date property sets the hour to 00)
            DateTime boundscheck = start.Date;
            // variable containing results
            int timesFound = 0;
            
            // This loop assumes we are only looking for one match per day
            for (int i = 0; i <= (end - start).Days; i++)
            {
                // set the lower bound to yyyy-mm-dd 12:00:00
                var lowerbound = boundscheck.Date.AddHours(12);
                // set the upper bound to yyyy-mm-dd 13:00:00
                var upperbound = lowerbound.AddHours(1);
                //determine if bounds are within our start and end date
                if (lowerbound >= start && upperbound <= end)
                {
                    timesFound++;
                }
                // increment boundscheck variable by one day
                boundscheck = boundscheck.AddDays(1);
            }
        }
