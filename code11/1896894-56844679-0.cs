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
