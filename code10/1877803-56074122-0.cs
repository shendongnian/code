    [BsonIgnoreExtraElements]
    public class CosmosDbData
    {
        [BsonId]
        public string Identifier { get; set; }
        public DateTime LastUpdateUtc { get; set; }
        public object Data { get; set; }
    }
