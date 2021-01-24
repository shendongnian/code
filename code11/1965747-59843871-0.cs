C#
private async Task RunFullImport(IProgress<float> progress) {
  var dataEntryCache = new ConcurrentHashSet<int>();
  using var client = new ESBClient(); // WCF
  var limiter = new SemaphoreSlim(10); // or however many you want to limit to.
  // Progress counters helpers
  float totalSteps = 1f / companyGroup.Count();
  int currentStep = 0;
  //Iterate over all resources
  await Task.WhenAll(companyGroup.Select(async res => {
    await limiter.WaitAsync();
    try {    
      getWorkOrderForResourceDataSetResponse worResp = ...
      // Iterate over all work orders and add them to the list
      foreach (dsyWorkOrder02TtyWorkOrderResource workOrder in worResp.dsyWorkOrder02) {
        dataEntryCache.Add(workOrder.DataEntryNumber.Value);
      }
      // Update progress
      progress.Report(totalSteps * Interlocked.Increment(ref currentStep) * .1f);
    }
    finally {
      limiter.Release();
    }
  }));
  // Do some more stuff with the result
}
For more information, see recipe 12.5 in [my book][1], which covers several different solutions for throttling.
  [1]: https://stephencleary.com/book/
