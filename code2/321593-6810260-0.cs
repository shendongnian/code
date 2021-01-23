    [JsonObject(MemberSerialization.OptIn)]
    public class Directory
    {
        [JsonProperty]
        public int id { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public int parent { get; set; }
