      MongoCollection<BsonDocument> places =
                   database.GetCollection<BsonDocument>("places");
           
                BsonDocument[] batch = {
                                           new BsonDocument { { "name", "Bran" }, { "loc", new BsonArray(new[] { 10, 10 }) } },
                                           new BsonDocument { { "name", "Ayla" }, { "loc", new BsonArray(new[] { 0, 0 }) } }
                };
                places.InsertBatch(batch);
                places.EnsureIndex(IndexKeys.GeoSpatial("loc"));
                var queryplaces = Query.WithinCircle("loc", 5, 5, 10);
                var cursor = places.Find(queryplaces);
                foreach (var hit in cursor)
                {
                    Console.WriteLine("in circle");
                    foreach (var VARIABLE in hit)
                    {
                        Console.WriteLine(VARIABLE.Value);
                    }
                }
