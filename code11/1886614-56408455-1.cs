C#
public sealed class AsyncLazy<T>
{
  private readonly object _mutex;
  private readonly Func<Task<T>> _factory;
  private Lazy<Task<T>> _instance;
  public AsyncLazy(Func<Task<T>> factory)
  {
    _mutex = new object();
    _factory = RetryOnFailure(factory);
    _instance = new Lazy<Task<T>>(_factory);
  }
  private Func<Task<T>> RetryOnFailure(Func<Task<T>> factory)
  {
    return async () =>
    {
      try
      {
        return await factory().ConfigureAwait(false);
      }
      catch
      {
        lock (_mutex)
        {
          _instance = new Lazy<Task<T>>(_factory);
        }
        throw;
      }
    };
  }
  public Task<T> Task
  {
    get
    {
      lock (_mutex)
        return _instance.Value;
    }
  }
  public TaskAwaiter<T> GetAwaiter()
  {
    return Task.GetAwaiter();
  }
  public ConfiguredTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext)
  {
    return Task.ConfigureAwait(continueOnCapturedContext);
  }
}
