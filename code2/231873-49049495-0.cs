    public static TId GetId<TId>(this BsonDocument document) where TId : struct
    {
        if (document == default(BsonDocument))
        {
            throw new ArgumentNullException("document");
        }
    
        var id = document["_id"];
    
        object idAsObject;
    
        if (id.IsGuid)
        {
            idAsObject = (object)id.AsGuid;
        }
        else if (id.IsObjectId)
        {
            idAsObject = (object)id.AsObjectId;
        }
        else
        {
            throw new NotImplementedException(string.Format("Unknown _id type \"{0}\"", id.BsonType));
        }
    
        var idCasted = (TId)idAsObject;
    
        return idCasted;
    }
