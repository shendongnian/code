var partitionQuery = TableQuery.GenerateFilterCondition
                     ("PartitionKey", QueryComparisons.Equal, myKey);
or 
var startQ = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThan, start);
var endQ= TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, end);
var q = TableQuery.CombineFilters(startQ, TableOperators.And, endQ);
Step 2. Get the data
public async Task<List<T>> GetDataAsync<T>(TableQuery<T> query)
{
    var l = new List<T>();
    TableContinuationToken continuationToken = null;
    do
    {
        var queryResponse = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
        continuationToken = queryResponse.ContinuationToken;
        l.AddRange(queryResponse.Results);
    } 
    while (continuationToken != null);
    return l;
}
