    public static class QueryExtensions
    {
        public static async Task<IEnumerable<TElement>> ExecuteQueryAllElementsAsync<TElement>(this CloudTable table, TableQuery<TElement> tableQuery)
            where TElement : ITableEntity, new()
        {
            TableContinuationToken continuationToken = default(TableContinuationToken);
            var results = new List<TElement>(0);
            tableQuery.TakeCount = 500;
            do
            {
                //Execute the next query segment async.
                var queryResult = await table.ExecuteQuerySegmentedAsync(tableQuery, continuationToken);
                //Set exact results list capacity with result count.
                results.Capacity += queryResult.Results.Count;
                results.AddRange(queryResult.Results);
                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);
            return results;
        }
    }
