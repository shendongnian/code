    [JsonObject(ItemRequired = Required.Always)]
    public class Event
    {
        public string DataSource { get; set; }
        public string LoadId { get; set; }
        public string LoadName { get; set; }
        public string MonitorId { get; set; }
        public string MonitorName { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Value { get; set; }
    }
