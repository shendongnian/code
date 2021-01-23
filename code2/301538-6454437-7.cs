     public List<IIdentity> FindIdentities(List<IdentityAttributeSearch> searchAttributes)
     {
            var server = MongoServer.Create("mongodb://localhost/");
            var db = server.GetDatabase("IdentityManager");
            var collection = db.GetCollection<MongoIdentity>("Identities");
            MongoQueryAll qAll = new MongoQueryAll("Relationships");
            foreach (var search in searchAttributes)
            {
                MongoQueryElement qE = new MongoQueryElement();
                qE.QueryPredicates.Add(new MongoQueryPredicate("RelationshipType", search.RelationshipType));
                qE.QueryPredicates.Add(new MongoQueryPredicate("Attributes." + search.Name, search.Datum));
                qAll.QueryElements.Add(qE);
            }
            BsonDocument doc = MongoDB.Bson.Serialization
                    .BsonSerializer.Deserialize<BsonDocument>(qAll.ToString());
            var identities = collection.Find(new QueryComplete(doc)).ToList();
            return identities;
        }
