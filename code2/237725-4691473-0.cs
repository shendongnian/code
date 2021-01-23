        public IList<DateTime> GetMissingMonths(IList<DateTime> currentList, DateTime startDate, DateTime endDate)
        {
            // Create a list for the missing months
            IList<DateTime> missingList = new List<DateTime>();
            // Select a startdate
            DateTime testingDate = startDate;
            // Begin by the month of startDate and ends with the month of endDate
            // month of startDate and endDate included
            while(testingDate <= endDate)
            {
                if (currentList.Count(m => m.Month == testingDate.Month && m.Year == testingDate.Year) == 0)
                {
                    missingList.Add(new DateTime(testingDate.Year, testingDate.Month, 1));
                }
                testingDate = testingDate.AddMonths(1);
            }
            return missingList;
        }
