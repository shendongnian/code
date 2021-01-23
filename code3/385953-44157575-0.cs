		var findOptions = new FindOptions<BsonDocument>();
		findOptions.Projection = "{'_id': 1}";
		
		// Other options
		findOptions.Sort = Builders<BsonDocument>.Sort.Ascending("name");			
		findOptions.Limit = int.MaxValue;
		var collection = context.MongoDatabase.GetCollection<BsonDocument>("yourcollection");	
					
		using (var cursor = collection.FindSync("{name : 'Bob'}", options))
		{
			while (cursor.MoveNext())
			{
				var batch = cursor.Current;
				foreach (BsonDocument document in batch)
				{
					// do stuff...
				}
			}
		}
