    public class DTO
    {
        [JsonIgnore]
        public bool IsWritingToDatabase { get; set; }
        public string AlwaysSerialize { get; set; }
        public string Optional { get; set; }
        public bool ShouldSerializeOptional()
        {
            return IsWritingToDatabase;
        }
    }
