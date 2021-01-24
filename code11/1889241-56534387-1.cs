    [JsonConverter( typeof( ArrayToObjectConverter ) )]
    public class Obj {
        [JsonProperty]
        internal string Item0 { get; set; }
        [JsonProperty]
        internal decimal Item1 { get; set; }
        [JsonIgnore]
        public string Text { get => Item0; set => Item0 = value; }
        [JsonIgnore]
        public decimal Number { get => Item1; set => Item1 = value; }
    }
