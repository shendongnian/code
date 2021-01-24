    public class Foo
    {
        public string TimeZoneId { get; set; }
        public TimeZoneInfo TimeZone
        {
            get => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId);
            set => TimeZoneId = value.Id;
        }
    }
