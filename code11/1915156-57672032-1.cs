    public class Item
    {
        public int Id { get; set; }
        [JsonProperty("pkID")]
        public int BackwardCompatibleId { set => Id = value; }
    }
    // test
    var x = new Item { Id = 88 };
    var json = JsonConvert.SerializeObject(x); // {"Id":88}
    var clone = JsonConvert.DeserializeObject<Item>("{\"pkId\":99}");
