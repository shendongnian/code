    public async Task<(IEnumerable<T> Results, string ContinuationToken)> Where<T>(Expression<Func<T, bool>> pred, int maxRecords = 0, string partitionKey = "", string continuationToken = "") where T : IDocumentModel
    {
        QueryRequestOptions options = new QueryRequestOptions();
        if (partitionKey != "")
            options.PartitionKey = new PartitionKey(partitionKey);
            
        if (maxRecords == 0)
        {
            return (Container.GetItemLinqQueryable<T>(true, null, options).Where(x => x.Type == typeof(T).Name).Where(pred), "");
        }
        else
        {
            options.MaxItemCount = maxRecords;
            string token = "";
            FeedIterator<T> feed;
            List<T> res = new List<T>();
            if (continuationToken == "")
                feed = Container.GetItemLinqQueryable<T>(true, null, options).Where(x => x.Type == typeof(T).Name).Where(pred).ToFeedIterator();
            else
                feed = Container.GetItemLinqQueryable<T>(true, continuationToken, options).Where(x => x.Type == typeof(T).Name).Where(pred).ToFeedIterator();
            Microsoft.Azure.Cosmos.FeedResponse<T> f = await feed.ReadNextAsync();
            token = f.ContinuationToken;
            foreach (var item in f)
            {
                res.Add(item);
            }
            return (res, token);
        }
    }
