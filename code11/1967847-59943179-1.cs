    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
          IEnumerable<string> businessIds = (from x in _db.Poslookup
                                   select x.BusinessId).Distinct();
         // Want to multi-thread a sync for each of the businesses in businessIds
         Parallel.ForEach(businessIds, async i =>
         {
             await SyncBusiness(i, stoppingToken);
         });
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    }
    private async Task SyncBusiness(string businessId, CancellationToken stoppingToken)
    {
        await new HttpClient().GetAsync($"https://example.com/endpoint/{businessId}", stoppingToken);
    }
