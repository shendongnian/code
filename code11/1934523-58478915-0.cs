    public class Item
    {
        [JsonProperty("itemLevel")]
        public long ItemLevel { get; set; }
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        [JsonProperty("itemType")]
        public string ItemType { get; set; }
    }
