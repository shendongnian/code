	private class ListRowsContinuationToken
	{
		public string NextPartitionKey { get; set; }
		public string NextRowKey { get; set; }
	}
    public Stories SelectStory(DateTime start, DateTime end, string searchGuid)
    {
    	long startTicks = DateTime.MaxValue.Ticks - start.ToUniversalTime().Ticks;
    	long endTicks = DateTime.MaxValue.Ticks - end.ToUniversalTime().Ticks;
	var stories = _ServiceContext.CreateQuery<Story>("Story").Where(s => s.PartitionKey > startTicks.ToString() + "_"
					&& s.PartitionKey < endTicks.ToString() + "_"
					&& s.RowKey == "story_" + searchGuid).Take(50);
	var query = stories as DataServiceQuery<Story>;
	Stories finalList = new Stories();
	var results = query.Execute();
	ListRowsContinuationToken continuationToken = null;
	bool reachedEnd = false;
	do
	{
		if ((continuationToken != null))
		{
			servicesQuery = servicesQuery.AddQueryOption("NextPartitionKey", continuationToken.NextPartitionKey);
			if (!string.IsNullOrEmpty(continuationToken.NextRowKey))
			{
				servicesQuery.AddQueryOption("NextRowKey", continuationToken.NextRowKey);
			}
		}
		var response = (QueryOperationResponse<T>)query.Execute();
		foreach (Story result in response)
		{
			if (result.PartitionKey < endTicks.ToString())
			{
				finalList.AddRange(result);
			}
			else
			{
				reachedEnd = true;
			}
		}
		if (response.Headers.ContainsKey("x-ms-continuation-NextPartitionKey"))
		{
			continuationToken = new ListRowsContinuationToken
			{
				NextPartitionKey = response.Headers["x-ms-continuation-NextPartitionKey"]
			};
			if (response.Headers.ContainsKey("x-ms-continuation-NextRowKey"))
			{
				continuationToken.NextRowKey = response.Headers["x-ms-continuation-NextRowKey"];
			}
		}
		else
		{
			continuationToken = null;
		}
					
	} while (continuationToken != null && reachedEnd == false);
	return finalList;
}
