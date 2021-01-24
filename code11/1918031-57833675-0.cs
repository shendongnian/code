        private Task LoadCollection(string collectionName, List<DateTime> dates) 
        {
            return Task.Run(() =>
            {
                var builder = Builders<BsonDocument>.Filter;
                var dateRangeFilters = new List<FilterDefinition<BsonDocument>>();
                foreach (DateTime item in dates)
                {
                    dateRangeFilters.Add(
                        builder.Gte("Date", item.Date) 
                        &
                        builder.Lt("Date", item.Date.AddDays(1)));
                }
                var anyOfTheseDatesFilter = builder.Or(dateRangeFilters);
                var filter = 
                      builder.Ne("Type", "Header") 
                    & builder.Ne("Type", (string)null)
                    & anyOfTheseDatesFilter
                ;
                var collectionDocuments =
                    Database
                    .GetCollection<BsonDocument>(collectionName)
                    .Find(filter)
                    .ToList()
                ;
