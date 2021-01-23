    public class MyViewModel
    {
        public IEnumerable<DayOfWeekViewModel> DaysOfWeek { get; set; }
        ... put any other properties that you consider useful for this view
    }
    public class DayOfWeekViewModel
    {
        public string DayOfWeek { get; set; }
        public bool IsSelected { get; set; }
    }
