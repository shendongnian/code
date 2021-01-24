    public class SubServiceDef
    {
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonId]
        public ObjectId FakeId { get; set; }
    }
