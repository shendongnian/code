C#
private readonly SemaphoreSlim _mutex = new SemaphoreSlim(10);
public async Task AddTask(Func<Task> work)
{
  await _mutex.WaitAsync();
  try { await work(); }
  finally { _mutex.Release(); }
}
> A timeout would be great as well, to prevent a task from being run undefinitely in case of a failure.
The standard pattern for timeouts is to use a `CancellationTokenSource` as the timer and pass a `CancellationToken` into the work that needs to support cancellation:
C#
private readonly SemaphoreSlim _mutex = new SemaphoreSlim(10);
public async Task AddTask(Func<CancellationToken, Task> work)
{
  await _mutex.WaitAsync();
  using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
  try { await work(cts.Token); }
  finally { _mutex.Release(); }
}
