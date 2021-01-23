            var updList = new List<UpdateDefinition<MongoLogEntry>>();
            var collection = db.GetCollection<MongoLogEntry>(HistoryLogCollectionName);
            var upd = Builders<MongoLogEntry>.Update.Set(r => r.Status, status)
                .Set(r => r.DateModified, DateTime.Now);
            updList.Add(upd);
            if (errorDescription != null)
                updList.Add(Builders<MongoLogEntry>.Update.Set(r => r.ErrorDescription, errorDescription));
            var finalUpd = Builders<MongoLogEntry>.Update.Combine(updList);
            collection.UpdateOne(r => r.CadNum == cadNum, finalUpd, new UpdateOptions { IsUpsert = true });
