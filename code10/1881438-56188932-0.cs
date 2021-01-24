C#
private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
public async Task<object> OnQuery (dynamic request, dynamic payload = null)
{
  await _mutex.WaitAsync();
  try
  {
    var result = new QueryCallback ();
    //...code...
    return result
  }
  finally
  {
    _mutex.Release();
  }
}
Side note: this is not technically a *queue*, since strict FIFO order isn't guaranteed. It is, however, a way to enforce exclusive access to a shared resource, and this should suffice for what you need.
