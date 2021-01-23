    public static Client FromBson(BsonValue bson)
    {
      if (bson == null || !bson.IsBsonDocument)
        return null;
      var doc = bson.AsBsonDocument;
      var client = new Client
      {
        ExtraFields = new List<ExtraField>(),
        Address = doc["Address"].AsString,
        Name = doc["Name"].AsString
      };
      foreach (var name in doc.Names)
      {
        var val = doc[name];
        if (val is BsonDocument)
        {
          var fieldDoc = val as BsonDocument;
          var field = new ExtraField
          {
            Key = name,
            Value = fieldDoc["Value"].AsString,
            Type = fieldDoc["Type"].AsString
          };
           client.ExtraFields.Add(field);
         }
       }
     return client;
    }
