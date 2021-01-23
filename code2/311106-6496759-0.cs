       public static List<string> TimeSpansInRange(TimeSpan start, TimeSpan end, TimeSpan interval)
        {
            List<string> timeSpans = new List<string>();
            while (start.Add(interval) <= end)
            {
                timeSpans.Add(start.Hours.ToString() +":"+start.Minutes.ToString());
                start = start.Add(interval);
            }
            return timeSpans;
        }
