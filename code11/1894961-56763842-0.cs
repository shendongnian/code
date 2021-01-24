    public class Scores  {
         [MongoDB.Bson.Serialization.Attributes.BsonElement]
         public ObjectId _id { get; set; }
         public Coordinate[] Coordinates { get; set; }
         public string Player { get; set; }
    }
