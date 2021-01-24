    public class DayTodayController : Controller
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public DayTodayController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        [HttpGet, Route ("GetDate")]
        public  string GetDate () {
            var info = $"Today is {_dateTimeProvider.Now().ToString("dddd, dd MMMM yyyy")} and the time is {DateTime.Now.ToString("hh:mm tt")}";
            return info;
        }
    }
