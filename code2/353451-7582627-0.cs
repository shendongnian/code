    IMongoSortBy sort = SortBy.Descending("Revision");
    IMongoQuery = Query.EQ("DocName", stFName);
    BsonValue maxRev = docs.FindAs<BsonDocument>(q).SetFields(new string[] {"Revision"}).SetSortOrder(sort).SetLimit(1).GetFirstOrDefault()
    if (maxRev !=null)
        int revMax = maxRev.AsBsonDocument.GetValue("Revision").AsInt32; // <- this is the maximum revision
