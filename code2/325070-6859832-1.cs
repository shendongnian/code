    public class SomeDateTimeAttribute : Attribute
    {
        private DateTime _date;
        public SomeDateTimeAttribute(int year, int month, int day)
        {
            _date = new DateTime(year, month, day);
        }
        public SomeDateTimeAttribute(string date)
        {
            DateTime.TryParse(date, out _date);
        }
        public DateTime Date
        {
            get { return _date; }
        }
        public bool IsAfterToday()
        {
            return this.Date > DateTime.Today;
        }
    }
