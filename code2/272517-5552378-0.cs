    List<BsonValue> contactIds = new List<BsonValue>();
    contactIds.Add(new Guid("A04FC88D-7BF7-443D-B5C3-EB11EE2B36DF"));
    contactIds.Add(new Guid("26B690B3-5ED7-47F4-A878-3906E28BBC58"));
    MongoDB.Driver.Builders.QueryConditionList queryList = MongoDB.Driver.Builders.Query.In("_id", BsonArray.Create(contactIds));
    MongoDB.Driver.Builders.MapReduceOptionsBuilder builder=new MongoDB.Driver.Builders.MapReduceOptionsBuilder();
    builder.SetOutput(MongoDB.Driver.Builders.MapReduceOutput.Inline);
    var mr = personCollection.MapReduce(map, reduce, builder);
