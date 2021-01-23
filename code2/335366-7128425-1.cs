        public int DaysLeftInYear()
        {
            DateTime today = DateTime.Now;
            int daysInYear = 365;
            if (DateTime.IsLeapYear(today.Year))
            {
                daysInYear++;
            }
            return daysInYear - today.DayOfYear;
        }
