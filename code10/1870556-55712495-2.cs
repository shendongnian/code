    [BsonNoId]
    public class ChildDataModel : DataModel
    {        
        [BsonRepresentation(BsonType.ObjectId)]
        public override string Id { get; set; }
    }
