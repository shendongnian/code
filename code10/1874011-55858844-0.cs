csharp
static async Task Main(string[] args)
{
    var cancellationSources = Enumerable.Range(0, 3)
      .Select(_ => new CancellationTokenSource())
      .ToList();
    var tasks = Enumerable.Range(0, 3).Select(x => Task.Run(
        () => Counter(cancellationSources[x].Token),
        cancellationSources[x].Token
    ));
    cancellationSources[1].Cancel();
    await Task.WhenAll(tasks);
    Console.ReadLine();
}
public static void Counter(CancellationToken cancellationToken)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        // or while(true) and token.ThrowIfCancellationRequested(); to throw instead
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(i);
        }
    }
}
