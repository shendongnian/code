    public void Insert(List<BsonDocument> list)
        {
            try
            {
                var collection = this.db.GetCollection<BsonDocument>(COLLECTION_NAME);
                collection.InsertMany(list);
            } catch (MongoBulkWriteException ex)
            {
                int index = ex.WriteErrors[0].Index;
                Insert(list.GetRange(index, list.Count - index));
            }
            
        }
