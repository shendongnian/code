    public class Calendar
    {
        private readonly List<CalendarDate> _dates = new List<CalendarDate>();
        
        public Calendar(
            DateTime startDate, 
            int length, 
            ICollection<DateTime> holidays,
            ICollection<DayOfWeek> weekDays)
        {
            if(length < 1)
                throw new ArgumentOutOfRangeException(nameof(length), "The minimum length is one day.");
            for (var x = 0; x < length; x++)
            {
                var addingDate = new CalendarDate
                {
                    RepresentedDate = startDate.Date.AddDays(x),
                };
                addingDate.IsHoliday = holidays.Contains(addingDate.RepresentedDate);
                addingDate.IsWeekday = weekDays.Contains(addingDate.RepresentedDate.DayOfWeek);
                _dates.Add(addingDate);
            }
            FirstDay = startDate.Date;
            LastDay = FirstDay.AddDays(length - 1);
        }
        public DateTime FirstDay { get; }
        public DateTime LastDay { get; }
        private class CalendarDate
        {
            internal DateTime RepresentedDate { get; set; }
            internal bool IsHoliday { get; set; }
            internal bool IsWeekday { get; set; }
            internal bool IsWorkingDay => !(IsHoliday || IsWeekday);
        }
        public DateTime GetNextWorkingDay(DateTime date)
        {
            date = date.Date;
            ValidateDateIsInRange(date);
            var result = _dates.FirstOrDefault(d => 
                d.RepresentedDate >= date && d.IsWorkingDay);
            if (result != null) return result.RepresentedDate;
            throw new InvalidOperationException("The result is outside the range of the calendar.");
        }
        private void ValidateDateIsInRange(DateTime date)
        {
            if(date < FirstDay || date > LastDay)
                throw new InvalidOperationException("The specified date is outside the range of the calendar.");
        }
    }
