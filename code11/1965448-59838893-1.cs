    public partial class OBSSource
    {
        [JsonProperty("item-id")]
        public long ItemId { get; set; }
        [JsonProperty("item-name")]
        public string ItemName { get; set; }
        [JsonProperty("item-visible")]
        public bool ItemVisible { get; set; }
        [JsonProperty("scene-name")]
        public string SceneName { get; set; }
        [JsonProperty("update-type")]
        public string UpdateType { get; set; }
    }
