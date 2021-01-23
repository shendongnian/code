    if (!MongoDB.Bson.Serialization.BsonClassMap.IsClassMapRegistered(typeof(Person)))
          {
            MongoDB.Bson.Serialization.BsonClassMap.RegisterClassMap<Person>(cm =>
             {
               cm.AutoMap();
               cm.GetMemberMap(c => c.Gender).SetRepresentation(BsonType.String);
    
             });
          }
