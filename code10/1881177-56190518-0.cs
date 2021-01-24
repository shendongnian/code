    private async Task CreateChangeFeed<T>(
        DocumentCollectionInfo feedCollectionInfo, 
        DocumentCollectionInfo leaseCollectionInfo, 
        ChangeFeedProcessorOptions options) 
        where T : Microsoft.Azure.Documents.ChangeFeedProcessor.FeedProcessing.IChangeFeedObserver, new ()
    {
        var processor = await new ChangeFeedProcessorBuilder()
               .WithHostName("CosmosDBDetectorHost")
               .WithFeedCollection(feedCollectionInfo)
               .WithLeaseCollection(leaseCollectionInfo)
               .WithProcessorOptions(new ChangeFeedProcessorOptions()
               {
                   FeedPollDelay = new TimeSpan(0, ChangeFeedOptionsConstants.MinutesInterval, 0),
                   MaxItemCount = ChangeFeedOptionsConstants.MaxItemCount,
               })
               .WithObserver<T>()
               .BuildAsync();
    }
