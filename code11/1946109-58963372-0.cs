    public class Model
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        public Model(ObjectId id)
        {
            ID = id;
        }
    }
