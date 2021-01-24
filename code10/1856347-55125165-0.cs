    var client = new MongoClient();
    var database = client.GetDatabase("test");
    var collection = database.GetCollection<Central>("dbCENTRAL");
    var filter = Builders<Central>.Filter.Eq(x => x.PartnerId, "2021")
                           & Builders<Central>.Filter.Gte(x => x.DATAINST, "2018-01-01 00:00:00")
                           & Builders<Central>.Filter.Lte(x => x.DATAINST, "2019-03-12 23:59:59");
    var listAsync = await collection.Aggregate()
        .Match(filter)
        .Group(central => central.DATAINST.Substring(0, 10), g => new { Id = g.Key, Count = g.Count()})
        .ToListAsync();
