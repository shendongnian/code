    public class Sensor
    {
        public long Id { get; set; }
        [Required]
        public string Tag { get; set; }
        public long Timestamp { get; set; }
        public DateTime TimestampDt
        { 
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(Timestamp).UtcDateTime;
            }
        }
        public string Status { get; set; }
        public int Valor { get; set; }
    }
