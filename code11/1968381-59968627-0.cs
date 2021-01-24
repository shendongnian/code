    public class CharInsert : Edit
    {
        [JsonProperty(PropertyName = "p")]
        public int ParagraphIndex { get; set; }
        [JsonProperty(PropertyName = "i")]
        public int CharacterIndex { get; set; }
        [JsonProperty(PropertyName = "c")]
        public char Character { get; set; }
    }
