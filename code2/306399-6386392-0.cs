        public Dictionary<DateTime, int> GetMontsBetween(DateTime startDate, DateTime EndDate)
        {
            Dictionary<DateTime, int> rtnValues = new Dictionary<DateTime, int>();
            DateTime startMonth = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime endMonth = new DateTime(EndDate.Year, EndDate.Month, 1);
            //some checking
            if (startDate >= EndDate)
            {
                rtnValues.Add(startMonth, 0); // Or return null;
            }
            else if (startDate.Month == EndDate.Month && startDate.Year == EndDate.Year)
            {
                rtnValues.Add(startMonth, EndDate.Day - startDate.Day);
            }
            else
            {
                //Add first month remaining days
                rtnValues.Add(startMonth, DateTime.DaysInMonth(startDate.Year, startDate.Month) - startDate.Day);
                //Add All months days inbetween
                for (DateTime st = startMonth.AddMonths(1); st < endMonth; st = st.AddMonths(1))
                {
                    rtnValues.Add(new DateTime(st.Year, st.Month, 1), DateTime.DaysInMonth(st.Year, st.Month) );
                }
                //Add last month days
                rtnValues.Add(new DateTime(EndDate.Year, EndDate.Month, 1), EndDate.Day);
            }
            return rtnValues;
        }
