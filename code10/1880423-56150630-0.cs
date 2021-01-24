C#
public static async Task ServiceLoop() {
  var awaitedQueue = Channel.CreateUnbounded<int>();
  var queueReader = awaitedQueue.Reader;
  while (await queueReader.WaitToReadAsync())
  {
    while (queueReader.TryRead(out var item))
    {
      Console.WriteLine(item);
    }
  }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.channels
