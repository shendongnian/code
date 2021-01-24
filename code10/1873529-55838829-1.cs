    public class MyClass
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [JsonConverter(typeof(StringToObjectId))]
        public ObjectId UserId { get; set; }
    }
