    public class Child
    {
        public int Id { get; set; }
        public string Type { get; set; }
        [JsonConverter(typeof(BsonToJsonConverter))]
        public BsonDocument Properties { get; set; }
    }
