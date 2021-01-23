    static class Extensions
    { 
        public static string ToShortForm(this TimeSpan t)
        {
            string shortForm = "";
            if (t.TotalMinutes <= 1)
            {
                shortForm = string.Format("{0}s", t.Seconds.ToString());
            }
            else if (t.TotalHours <= 1)
            {
                shortForm = string.Format("{0}m{1}s", t.Minutes.ToString(), t.Seconds.ToString());
            }
            else
            {
                shortForm = string.Format("{0}h{1}m{2}s", t.Hours.ToString(), t.Minutes.ToString(), t.Seconds.ToString());
            }
            return shortForm;
        } 
    } 
