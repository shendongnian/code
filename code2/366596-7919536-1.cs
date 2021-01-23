    public class Row
    {
        public string MonthWeek { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string WeekOfYear { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var l = new List<Row>();
            DateTime startDate = DateTime.Now;
            DateTime d = new DateTime(startDate.Year, startDate.Month, 1);
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var ms = cal.GetWeekOfYear(new DateTime(d.Year, d.Month, 1), System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday);
            for (var i = 1; d.Month == startDate.Month; d = d.AddDays(1))
            {
                var si = new Row();
                var month_week = (d.Day / 7) + 1;
                si.MonthWeek = month_week.ToString();
                si.Month = d.Year.ToString();
                si.Year = d.Month.ToString();
                si.Day = d.Day.ToString();
                si.WeekOfYear = cal.GetWeekOfYear(d, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
                l.Add(si);
            }
            dataGrid1.ItemsSource = l;
        }
    }
