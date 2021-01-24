    public static ConcurrentDictionary<string, Alarm> concurrentDictionary = new ConcurrentDictionary<string, Alarm>();
    //                                          ^^^ 
    public class Alarm
    {
        public int AlarmId { get; set; }
        public string AlarmName { get; set; }
        public string AlarmDescription { get; set; }
        public string ApplicationRoleId { get; set; }
        public DateTime DateTimeActivated { get; set; }
    }
