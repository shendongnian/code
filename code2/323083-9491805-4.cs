        public static string GetPersianDate(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));
        }
        //How to use it:
        DateTime d = new DateTime(2014, 05, 21);
        string s = d.GetPersianDate(); //1393/02/31
