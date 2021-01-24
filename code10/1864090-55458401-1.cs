    public class YourCollection
    {
        [BsonId()]        
        public ObjectId Id { get; set; }
        [BsonElement("YourCollectionID")]
        public string YourCollectionID { get; set; }
        [BsonElement("AccessKey")]
        public string AccessKey { get; set; }
    }
