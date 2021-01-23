    class Utils
    {
        public DateTime GetLastDateTime()
        {
            // Insert code here to return the last DateTime from your server.
            // Maybe from a database or file?
            // For now I'll just use the current DateTime:
            return DateTime.Now;
        }
        public CustomTimeSpan GetCurrentTimeSpan()
        {
            // You don't actually need this method. Just to expalin better...
            // Here you can get the diference (timespan) from one datetime to another:
            return new CustomTimeSpan(GetLastDateTime(), DateTime.Now);
        }
        public string FormatTimeSpan(CustomTimeSpan span)
        {
            // Now you can format your string to what you need, like:
            String.Format("{0} year{1}, {2} month{3}, {4} day{5}, {6} hour{7}, {8} minute{9} and {10} second{11}",
                span.Years, span.Years > 1 ? "s" : "",
                span.Months, span.Monts > 1 ? "s" : "",
                span.Days, span.Days > 1 ? "s" : "",
                span.Hours, span.Hours > 1 : "s" : "",
                span.Minutes, span.Minutes > 1 : "s" : "",
                span.Seconds, span.Seconds > 1 : "s" : "");
        }
    }
    class CustomTimeSpan : TimeSpan
    {
        public int Years { get; private set; }
        public int Months { get; private set; }
        public int Days { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public CustomTimeSpan ( DateTime originalDateTime, DateTime actualDateTime )
        {
            var span = actualDateTime - originalDateTime;
            this.Seconds = span.Seconds;
            this.Minutes = span.Minutes;
            this.Hours = span.Hours;
            // Now comes the tricky part: how to get the day, month and year part...
            var months = 12 * (actualDateTime.Year - originalDateTime.Year) + (actualDateTime.Month - originalDateTime.Month);
            int days = 0;
            if (actualDateTime.Day < originalDateTime.Day)
            {
                months--;
                days = GetDaysInMonth(originalDateTime.Year, originalDateTime.Month) - originalDateTime.Day + actualDateTime.Day;
            }
            else
            {
                days = actualDateTime.Day - originalDateTime.Day;
            }
            this.Years = months / 12;
            months -= years * 12;
            this.Months = months;
            this.Days = days;
        }
    }
