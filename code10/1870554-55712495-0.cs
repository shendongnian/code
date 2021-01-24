    public class ChildDataModel : DataModel
    {        
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnore]
        public override string Id { get; set; }
    }
