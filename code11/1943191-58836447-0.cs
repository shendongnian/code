    public class CustomDate
    {
        public int Day { get; set; }
        public int Year { get; set; }
        public CustomDate(int day, int year)
        {
            this.Day = day;
            this.Year = year;
        }
        public override string ToString()
        {
            return Year + "/" + Day;
        }
        public static implicit operator CustomDate(DateTime _dt) => new CustomDate(_dt.DayOfYear, _dt.Year);
        public static implicit operator DateTime(CustomDate _dt) => new DateTime(_dt.Year,1,1).AddDays(_dt.Day-1);
    }
