    public class BackupScheduleSettings
    {
        public BackupScheduleSettings()
        {
            ScheduledDay = new int[7];
        }
        [XmlElement(Order=1)]
        public int AggressiveMode;
        //[XmlArrayItem("ArrayWrapper")]
        [XmlElement(Order=2)]
        public int[] ScheduledDay { get; set; }
        [XmlElement(Order=3)]
        public int WindowStart;
        [XmlElement(Order=4)]
        public int WindowEnd;
        [XmlElement(Order=5)]
        public int ScheduleInterval;
    }
