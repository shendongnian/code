cs 
class Program
{
    static async Task Main(string[] args)
    {
        var tcs = new CancellationTokenSource();
        var task = Task.Run(() => RunAsync("1", tcs.Token));
        var task2 = Task.Run(() => RunAsync("2", tcs.Token));
        await Task.Delay(1000);
        tcs.Cancel();
        Console.ReadLine();
    }
    private static async Task RunAsync(string source, CancellationToken cancel)
    {
        bool finished = false;
        while (!cancel.IsCancellationRequested && !finished)
            finished = await FakeTask(source);
    }
    private static Task<bool> FakeTask(string source)
    {
        Console.WriteLine(source);
        return Task.FromResult(false);
    }
}
