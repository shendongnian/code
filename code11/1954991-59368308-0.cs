    public static class DateTimeHumanize
    {
        public static string Humanize(this DateTime input, DateTime comparisonBase)
        {
            var ts = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));
            int seconds = ts.Seconds, minutes = ts.Minutes, hours = ts.Hours, days = ts.Days;
            int years = 0, months = 0;
            // start approximate from smaller units towards bigger ones
            if (ts.Milliseconds >= 999)
            {
                seconds += 1;
            }
            if (seconds >= 59)
            {
                minutes += 1;
            }
            if (minutes >= 59)
            {
                hours += 1;
            }
            if (hours >= 23)
            {
                days += 1;
            }
            // month calculation 
            if (days >= 30 & days <= 31)
            {
                months = 1;
            }
            if (days > 31 && days < 365)
            {
                var factor = Convert.ToInt32(Math.Floor((double)days / 30));
                var maxMonths = Convert.ToInt32(Math.Ceiling((double)days / 30));
                months = (days >= 30 * factor) ? maxMonths : maxMonths - 1;
            }
            // year calculation
            if (days >= 365 && days <= 366)
            {
                years = 1;
            }
            if (days > 365)
            {
                var factor = Convert.ToInt32(Math.Floor((double)days / 365));
                var maxMonths = Convert.ToInt32(Math.Ceiling((double)days / 365));
                years = (days >= 365 * factor) ? maxMonths : maxMonths - 1;
            }
            
            if (years > 0)
            {
                return "Since " + ((years > 1) ? $"{years} years" : "last year");
            }
            if (months > 0)
            {
                return "Since " + ((months > 1) ? $"{months} months" : "last month");
            }
            if (days > 0)
            {
                return "Since " + ((days > 1) ? $"{days} days" : "yesterday");
            }
            if (hours > 0)
            {
                return "Since " + ((hours > 1) ? $"{hours} hours" : "one hour");
            }
            if (minutes > 0)
            {
                return "Since " + ((minutes > 1) ? $"{minutes} minutes" : "one minute");
            }
            return "Now";
        }
