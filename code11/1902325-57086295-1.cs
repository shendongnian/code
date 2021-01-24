c#
private async Task TaskWaitAll()
{
  var mutex = new SemaphoreSlim(20);
  IEnumerable<int> arr = Enumerable.Range(1, 100000);
  var tasks = arr.Select(async i =>
  {
    await mutex.WaitAsync();
    try { await CallSendAsync(i); }
    finally { mutex.Release(); }
  }).ToList();
  await Task.WhenAll(tasks);
}
  [1]: https://en.wikipedia.org/wiki/Ephemeral_port
