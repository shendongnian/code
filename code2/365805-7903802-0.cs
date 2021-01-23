    public static class DateTimeExtension
    {    
        public static Months GetMonth(this Date dt)
        {
            return (Months)dt.Month;
        }
        public static Months GetMonthStr(this Date dt)
        {
            return ((Months)dt.Month).ToString();
        }
    }
