    var server = MongoServer.Create("mongodb://localhost:27020");
    var database = server.GetDatabase("SO");
    var clients = database.GetCollection<Type>("clients");
    var client = new Client() {Id = ObjectId.GenerateNewId().ToString()};
    client.Name = "Andrew";
    client.Address = "Address";
    client.ExtraFields = new List<ExtraField>();
    client.ExtraFields.Add(new ExtraField()
    {
      Key = "key1",
      Type = "type1",
      Value = "value1"
    });
    client.ExtraFields.Add(new ExtraField()
    {
      Key = "key2",
      Type = "type2",
      Value = "value2"
    });
     //When inseting/saving use ToBson to serialize client
    clients.Insert(Client.ToBson(client));
    //When reading back from the database use FromBson method:
    var fromDb = Client.FromBson(clients.FindOneAs<BsonDocument>());
