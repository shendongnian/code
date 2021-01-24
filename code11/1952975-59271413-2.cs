    public async Task<bool> Update_NAME_OF_THE_ARRAY(string id)
    {
      var filter = Builders<History>.Filter.Eq("_id", ObjectId.Parse(id));
      var update = Builders<History>.Update.Combine(
        Builders<History>.Update.Set(x => x.NAME_OF_THE_ARRAY[-1].Flag, false);
      var result = await _historyCollection.UpdateOneAsync(filter, update);
      return result.ModifiedCount > 0;
    }
