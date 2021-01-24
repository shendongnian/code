    public class Rootobject
        {
            public Datum[] data { get; set; }
            public Status status { get; set; }
        }
    
        public class Status
        {
            public DateTime timestamp { get; set; }
        }
    
        public class Datum
        {
            public int id { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public Quote quote { get; set; }
        }
    
        public class Quote
        {
            public USD USD { get; set; }
            public BTC BTC { get; set; }
        }
    
        public class USD
        {
            public float price { get; set; }
            public long volume_24h { get; set; }
            public float percent_change_1h { get; set; }
            public float percent_change_24h { get; set; }
            public long market_cap { get; set; }
            public DateTime last_updated { get; set; }
        }
    
        public class BTC
        {
            public int price { get; set; }
            public int volume_24h { get; set; }
            public int percent_change_1h { get; set; }
            public int percent_change_24h { get; set; }
            public int percent_change_7d { get; set; }
            public int market_cap { get; set; }
            public DateTime last_updated { get; set; }
        }
