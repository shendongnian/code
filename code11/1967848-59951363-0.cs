C#
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
  var businessIds = (from x in _db.Poslookup
                     select x.BusinessId).Distinct();
  while (!stoppingToken.IsCancellationRequested)
  {
    var tasks = businessIds.Select(SyncBusiness).ToList();
    await Task.WhenAll(tasks);
    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    await Task.Delay(600000, stoppingToken);
  }
}
I'd also recommend making your database lookup asynchronous:
C#
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
  while (!stoppingToken.IsCancellationRequested)
  {
    var businessIds = (from x in _db.Poslookup
                       select x.BusinessId).Distinct().ToListAsync();
    var tasks = businessIds.Select(SyncBusiness).ToList();
    await Task.WhenAll(tasks);
    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    await Task.Delay(600000, stoppingToken);
  }
}
And the final observation is that this code current syncs all the businesses and *then* waits for ten minutes *in between* its work. If you want it to start running every 10 minutes, then you can start the timer at the beginning of the method:
C#
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
  while (!stoppingToken.IsCancellationRequested)
  {
    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    var timerTask = Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
    var businessIds = (from x in _db.Poslookup
                       select x.BusinessId).Distinct().ToListAsync();
    var tasks = businessIds.Select(SyncBusiness).ToList();
    tasks.Add(timerTask);
    await Task.WhenAll(tasks);
  }
}
