C#
static async Task Main(string[] args)
{
  var timeout = TimeSpan.FromSeconds(1);
  var cts = new CancellationTokenSource(timeout);
  try
  {
    await IndirectDelay(10, cts.Token);
    await Task.Delay(timeout + TimeSpan.FromSeconds(1));
    await IndirectDelay(10, cts.Token);
  }
  catch (OperationCanceledException ex) when (cts.IsCancellationRequested)
  {
    Console.WriteLine(ex.CancellationToken == cts.Token); // false
    Console.WriteLine("Our token is canceled.");
  }
  catch (OperationCanceledException)
  {
    Console.WriteLine("Canceled for some other reason.");
  }
  catch (Exception)
  {
    Console.WriteLine("General error.");
  }
}
private static async Task IndirectDelay(int timeout, CancellationToken token)
{
  using (var internalCts = new CancellationTokenSource())
  using (var cts = CancellationTokenSource.CreateLinkedTokenSource(token, internalCts.Token))
    await Task.Delay(timeout, cts.Token);
}
There is a possibility of a race condition where your code would *think* the cancellation happens because of the timeout but really it's because of a connection dropping (or whatever internal logic is going on), but in most cases this doesn't matter.
  [1]: https://docs.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads#listening-to-multiple-tokens-simultaneously
