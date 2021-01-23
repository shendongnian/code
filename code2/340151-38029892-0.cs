    public static string RelativeTime(DateTime Date, string NowText = "Now")
    {
        const int SECOND = 1;
        const int MINUTE = 60 * SECOND;
        const int HOUR = 60 * MINUTE;
        const int DAY = 24 * HOUR;
        const int MONTH = 30 * DAY;
        TimeSpan TimeSpan;
        double delta = 0d;
        //It's in the future
        if (Date > DateTime.UtcNow)
        {
            TimeSpan = new TimeSpan(Date.Ticks - DateTime.UtcNow.Ticks);
            delta = Math.Abs(TimeSpan.TotalSeconds);
            if (delta < 1 * MINUTE)
            {
                if (TimeSpan.Seconds == 0)
                    return NowText;
                else
                    return TimeSpan.Seconds == 1 ? "A second from now" : TimeSpan.Seconds + " seconds from now";
            }
            if (delta < 2 * MINUTE)
                return "A minute from now";
            if (delta < 45 * MINUTE)
                return TimeSpan.Minutes + " minutes from now";
            if (delta < 90 * MINUTE)
                return "An hour from now";
            if (delta < 24 * HOUR)
                return TimeSpan.Hours + " hours from now";
            if (delta < 48 * HOUR)
                return "Tomorrow";
            if (delta < 30 * DAY)
                return TimeSpan.Days + " days from now";
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)TimeSpan.Days / 30));
                return months <= 1 ? "A month from now" : months + " months from now";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)TimeSpan.Days / 365));
                return years <= 1 ? "A year from now" : years + " years from now";
            }
        }
        //It's in the past
        else if (Date < DateTime.UtcNow)
        {
            TimeSpan = new TimeSpan(DateTime.UtcNow.Ticks - Date.Ticks);
            delta = Math.Abs(TimeSpan.TotalSeconds);
            if (delta < 1 * MINUTE)
            {
                if (TimeSpan.Seconds == 0)
                    return NowText;
                else
                    return TimeSpan.Seconds == 1 ? "A second ago" : TimeSpan.Seconds + " seconds ago";
            }
            if (delta < 2 * MINUTE)
                return "A minute ago";
            if (delta < 45 * MINUTE)
                return TimeSpan.Minutes + " minutes ago";
            if (delta < 90 * MINUTE)
                return "An hour ago";
            if (delta < 24 * HOUR)
                return TimeSpan.Hours + " hours ago";
            if (delta < 48 * HOUR)
                return "Yesterday";
            if (delta < 30 * DAY)
                return TimeSpan.Days + " days ago";
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)TimeSpan.Days / 30));
                return months <= 1 ? "A month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)TimeSpan.Days / 365));
                return years <= 1 ? "A year ago" : years + " years ago";
            }
        }
        //It's now
        else
            return NowText;
    }
