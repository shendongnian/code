    public class Activity
    {
        public string StartTime { get; set; }
        public string Duration { get; set; }
        public string ActivityType { get; set; }
    }
    public class RootObject
    {
        public string LicenceNumber { get; set; }
        public string CardNumber { get; set; }
        public List<Activity> Activities { get; set; }
    }
