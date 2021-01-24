    public class auction_id
    {
        public string name { set; get; }
        public IDictionary<int, Sub_auction_id> items { set; get; }
    }
    public class Sub_auction_id
    {
        public string pos { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string coords { get; set; }
    }
