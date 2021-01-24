    public interface IEntity
    {
        [BsonId]
        ObjectId _id { get; set; }
        string Message { get; set; }
    }
