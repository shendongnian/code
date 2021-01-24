var batch = IndexBatch.New(actions);
try
{
	var data = GetIndexClient(IndexName).Documents.Index(batch);
	var passResultCount = data.Results.Where(x => x.Succeeded).Count();
	var failResultCount = data.Results.Where(x => x.Succeeded==false).Count();
	var MessageResult = data.Results.Where(x => !string.IsNullOrEmpty(x.ErrorMessage));
	var keyResult = data.Results.Where(x => !string.IsNullOrEmpty(x.Key)).Select(x=>x.Key).ToList();
	var unikKey = keyResult.Distinct().ToList();
	string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
}
catch (IndexBatchException e)
{
	// Sometimes when your Search service is under load, indexing will fail for some of the documents in
	// the batch. Depending on your application, you can take compensating actions like delaying and
	// retrying. For this simple demo, we just log the failed document keys and continue.
	Console.WriteLine(
		"Failed to index some of the documents: {0}",
		String.Join(", ", e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)));	
}
           
**Note:** in `unikKey` result can find out the actual result which one update or created in azure server.
