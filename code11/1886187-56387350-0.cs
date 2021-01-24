C#
class TaskSchedulerTest
{
  private readonly SemaphoreSlim _mutex = new SemaphoreSlim(2);
  public async Task RunAsync()
  {
    var tasks = Enumerable.Range(1, 2).Select(id => DoWorkAsync(id));
    await Task.WhenAll(tasks);
  }
  private async Task DoWorkAsync(int id)
  {
    await _mutex.WaitAsync();
    try
    {
      Console.WriteLine($"Starting Work {id}");
      await HttpClientGetAsync();
      Console.WriteLine($"Finished Work {id}");
    }
    finally
    {
      _mutex.Release();
    }
  }
  async Task HttpClientGetAsync()
  {
    await Task.Delay(2000);
  }
}
  [1]: https://blog.stephencleary.com/2012/02/async-and-await.html
  [2]: https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
