    public class Root
    {
        public Dictionary<DateTime, PriceHistory> TimeSeries { get; set; }
    }
    public class PriceHistory
    {
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
    }
