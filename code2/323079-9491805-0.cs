        public static string GetDayOfWeekName(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            DateTime d = jc.ToDateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, PersianCalendar.PersianEra);
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "يکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه‏شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنجشنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
            }
