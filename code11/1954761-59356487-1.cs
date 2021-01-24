    [BsonIgnoreExtraElements]
    public class MyDbObject
    {
        [BsonId]
        public ObjectId ID { get; set; }
    
        [BsonElement("etc")]
    //etc
      }
 
