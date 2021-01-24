csharp
public class auction_js_min
{
        [JsonProperty("1")]
        public auction_id auction_id { set; get; }
    }
    public class auction_id
    {
        public string name { set; get; }
        public Items items { set; get; }
    }
    public class Items
    {
        [JsonProperty("2")]
        public Sub_auction_id sub_auction_id { set; get; }
    }
    public class Sub_auction_id
    {
        public string pos { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string coords { get; set; }
    }
