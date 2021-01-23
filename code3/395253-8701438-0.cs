    public static class Ext
    {
        public static string HowMuchAgo(this DateTime dt)
        {
            var difference = (DateTime.Now - dt);
            if (difference < TimeSpan.FromSeconds(.5))
            {
                return "Just now!";
            }
            else if (difference < TimeSpan.FromMinutes(1))
            {
                return difference.Seconds + " seconds ago.";
            }
            else if (difference < TimeSpan.FromHours(1))
            {
                return difference.Minutes + " minutes and " + difference.Seconds + " seconds ago.";
            }
            else if (difference < TimeSpan.FromDays(1))
            {
                return difference.Hours + " hours and " + difference.Minutes + " minutes and " + difference.Seconds + " seconds ago.";
            }
            else if (difference > TimeSpan.FromDays(1) && difference < TimeSpan.FromDays(2))
            {
                return "Yesterday at " + dt.ToShortTimeString();
            }
            else
            {
                return "On " + dt.ToString();
            }
        }
    }
