    public class FuzzyDate
    {
        int _year;
        int? _month;
        int? _day;
        public DateTime Date { get; set; }
        public DateType Type { get; set; }
        public DateTime GetDateTime(DateType dateType) { // ...
    }
    public enum DateType
    {
        DayMonthYear,
        MonthYear,
        Year
    }
