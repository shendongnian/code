C#
class Program  // use async/await
{
  static async Task Main(string[] args)
  {
    var task = ReadFileAsync();
    Console.WriteLine("Do other work");
    var result = await task;
    Console.WriteLine($"Read {result} lines");
    Console.ReadLine();
  }
  static async Task<int> ReadFileAsync()
  {
    await Task.Delay(5000); // simulate read operation
    return 9999;            // 9999 lines has been read
  }
}
In the general I/O case, [there is no thread][1]. This is why using `Thread.Sleep` throws everything off; it forces a thread to be used, when I/O doesn't need one.
  [1]: https://blog.stephencleary.com/2013/11/there-is-no-thread.html
