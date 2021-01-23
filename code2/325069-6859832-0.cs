    public class SomeDateTimeAttribute : Attribute
    {
        private int _year;
        private int _month;
        private int _day;
        public SomeDateTimeAttribute(int year, int month, int day)
        {
            _year = year;
            _month = month;
            _day = day;
        }
        public DateTime ProvidedDate
        {
            get { return new DateTime(_year, _month, _day); }
        }
        public bool IsAfterToday()
        {
            return this.ProvidedDate > DateTime.Today;
        }
    }
