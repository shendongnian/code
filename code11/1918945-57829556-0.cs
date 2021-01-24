c#
static void Main(string[] args)
{
    BlockingCollection<int> c1 = new BlockingCollection<int>(), c2 = new BlockingCollection<int>();
    Task task = Produce(c1, c2);
    while (BlockingCollection<int>.TryTakeFromAny(new[] { c1, c2 }, out int value, -1) >= 0)
    {
        Console.WriteLine($"value: {value}");
    }
    Console.WriteLine($"task.IsCompleted: {task.IsCompleted}");
    task.Wait();
}
private static async Task Produce(BlockingCollection<int> c1, BlockingCollection<int> c2)
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    c1.Add(1);
    await Task.Delay(TimeSpan.FromSeconds(1));
    c1.CompleteAdding();
    await Task.Delay(TimeSpan.FromSeconds(1));
    c2.Add(2);
    await Task.Delay(TimeSpan.FromSeconds(1));
    c2.CompleteAdding();
}
