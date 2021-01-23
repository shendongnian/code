        public static DateTime GetDateTimeFromJalaliString(this string jalaliDate)
        {
            PersianCalendar jc = new PersianCalendar();
            try
            {
                string[] date = jalaliDate.Split('/');
                int year = Convert.ToInt32(date[0]);
                int month = Convert.ToInt32(date[1]);
                int day = Convert.ToInt32(date[2]);
                DateTime d = jc.ToDateTime(year, month, day, 0, 0, 0, 0, PersianCalendar.PersianEra);
                return d;
            }
            catch
            {
                throw new FormatException("The input string must be in 0000/00/00 format.");
            }
        }
        //How to use it:
        string pdate = "1392/02/31";
        DateTime dateFromJalali = pdate.GetDateTimeFromJalaliString(); //{5/21/2014 12:00:00 AM}
