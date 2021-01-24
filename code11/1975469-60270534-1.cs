            var listToFind = new List<string> { "a", "b", "astring" };
            var regexList = listToFind.Select(x => new BsonRegularExpression(x, "i"));
            var filterList = new List<FilterDefinition<MyObject>>();
            foreach (var bsonRegularExpression in regexList)
            {
                FilterDefinition<MyObject> fil = Builders<MyObject>.Filter.ElemMatch(o => o.arrayProperty, Builders<ArrayProperty>.Filter.Regex(
                     x => x.string1,
                     bsonRegularExpression));
                filterList.Add(fil);
            }
            var orFilter = Builders<MyObject>.Filter.Or(filterList);
            var result = collection.Find(orFilter).ToList();
