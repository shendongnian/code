    public class TimeHelper
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    
        public static List<TimeSpan> TimeSpansInRange(TimeSpan start, TimeSpan end, TimeSpan interval)
        {
            List<TimeSpan> timeSpans = new List<TimeSpan>();
            TimeSpan now = DateTime.Now.TimeOfDay;
            while (start.Add(interval) <= end)
            {
                if(start.Add(interval) > now){
                    timeSpans.Add(start);
                }
                start = start.Add(interval);
            }
            return timeSpans;
        }
    
        public static List<TimeSpan> PossibleTimeSpansInDay()
        {
            return TimeSpansInRange(new TimeSpan(8, 0, 0), new TimeSpan(22, 30, 0), new TimeSpan(0, 30, 0));
        }
    }
