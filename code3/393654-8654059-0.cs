        public static DateTime AddBusinessHours(DateTime date, long hours)
        {
            int i = 0;
                        
            DateTime tmpDate = date;
            do
            {
                tmpDate = tmpDate.AddHours(1);
                if (!IsWeekend(tmpDate) && !IsHoliday(tmpDate) && IsOfficeHours(tmpDate))
                    i++;
            }
            while (i < hours);
            return tmpDate;
        }
        public static bool IsWeekend(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }
        public static bool IsHoliday(DateTime date)
        {
            //All dates in the holiday calendar are without hours and minutes.
            //With the normal date object, the Contains does not work.
            DateTime tmp = new DateTime(date.Year, date.Month, date.Day); 
            HolidayCalendar calendar = HolidayCalendar.Instance;
            return (calendar.Dates.Contains(tmp));
        }
        public static bool IsOfficeHours(DateTime date)
        {
            return (date.Hour >= 8 && date.Hour < 20);   //Office Hours are between 8AM and 8PM
        }
