5 clients, 1000ms result time:
ExecuteAsync returned in 00:00:01.0635000.
ExecuteSync  returned in 00:00:01.0573753.
1000 clients, 1000ms results time:
ExecuteAsync returned in 00:00:01.1669238.
ExecuteSync  returned in 00:00:38.8700007.
As you increase either the number of clients, or the length of the database call Async will significantly outperform Sync.
Also note, the shortest length of time a test could run is the database call time. This means Async was only took 2.62x as long to run 200 times more calls, whereas Sync took 677x longer.
The test program:
static int numClients = 1000;
static int databaseCallTime = 1000;
static void Main(string[] args)
{
    var aSW = new Stopwatch();
    aSW.Restart();
    {
        ExecuteAsync();
        Console.WriteLine($"ExecuteAsync returned in {aSW.Elapsed}.");
    }
    aSW.Restart();
    {
        ExecuteSync();
        Console.WriteLine($"ExecuteSync  returned in {aSW.Elapsed}.");
    }
}
public static void ExecuteAsync()
{
    int completed = 0;
    // load the server with a bunch of simutaneous database calls
    for (int i = 0; i < numClients; i++)
    {
        Task.Run(async () =>
        {
            await LongRunningDatabaseCallAsync();
            Interlocked.Increment(ref completed);
        });
    }
    // wait for all the clients to complete
    while (true) if (completed == numClients) break;
}
public static void ExecuteSync()
{
    int completed = 0;
    for (int i = 0; i < numClients; i++)
    {
        Task.Run(() =>
        {
            LongRunningDatabaseCallSync();
            Interlocked.Increment(ref completed);
        });
    }
    while (true) if (completed == numClients) break;
}
public static void LongRunningDatabaseCallSync()
{
    Thread.Sleep(databaseCallTime);
}
public static async Task LongRunningDatabaseCallAsync()
{
    await Task.Delay(databaseCallTime);
}
