        public int DaysLeftInYear()
        {
            int daysInYear = 365;
            if (DateTime.IsLeapYear(DateTime.Now.Year))
            {
                daysInYear++;
            }
            return daysInYear - DateTime.Now.DayOfYear;
        }
