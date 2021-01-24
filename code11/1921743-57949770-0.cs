    public class Engine
    {
        [Key]
        public string Id { get; set; }
        [JsonIgnore]
        public int engineNo { get; set; }
        [JsonIgnore]
        public string engineHost { get; set; }
    }
