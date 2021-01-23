        private DateTime thirdSunday(DateTime timeFrom)
        {
            List<DateTime> days = new List<DateTime>();
            DateTime testDate = timeFrom;
            while (testDate < timeFrom.AddMonths(1))
            {
                if (testDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    days.Add(testDate);
                }
                testDate = testDate.AddDays(1);
            }
            return days[2];
        }
