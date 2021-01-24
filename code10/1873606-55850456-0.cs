C#
class AsyncChannels : IDisposable
{
  Channel<TaskCompletionSource<bool>> _Channel;
  Task _Thread;
  CancellationTokenSource _Cancellation;
  public AsyncChannels()
  {
    _Channel = Channel.CreateUnbounded<TaskCompletionSource<bool>>();
    _Thread = Task.Run(() => WorkerAsync());
    _Cancellation = new CancellationTokenSource();
  }
  private async Task WorkerAsync()
  {
    try
    {
      while (await _Channel.Reader.WaitToReadAsync(_Cancellation.Token))
        while (_Channel.Reader.TryRead(out var item))
          item.TrySetResult(true);
    }
    catch (OperationCanceledException)
    {
    }
  }
  public void Dispose()
  {
    _Cancellation.Cancel();
    _Channel.Writer.TryComplete();
  }
  ...
}
  [1]: https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/
