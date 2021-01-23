    public class City
    {
        public string Cityname { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal Timezoneoffset { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
    public class Response
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
