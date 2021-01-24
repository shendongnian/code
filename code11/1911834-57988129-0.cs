`   
var query = this.container.GetItemLinqQueryable<T>(
         requestOptions: new QueryRequestOptions
         {
             PartitionKey = new PartitionKey(yourKey),
             MaxItemCount = maxCount
         }
     )
     .Where(yourPredicate);
 var feedIterator = this.container.GetItemQueryIterator<T>(query.ToQueryDefinition());
 var results = new List<T>();
 while (feedIterator.HasMoreResults)
 {
   results.AddRange(await feedIterator.ReadNextAsync());
 }
