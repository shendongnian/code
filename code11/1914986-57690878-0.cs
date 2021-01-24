    public async Task Remove(ObjectId id)
    {
        var context = new Context();
        var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
        var update = Builders<BsonDocument>.Update
            .Unset("evaluationContext.markersData_con");
        await context.MyCollection.FindOneAndUpdateAsync(filter, update);
    }
