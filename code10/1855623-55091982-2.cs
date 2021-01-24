static void Main(string[] args)
{
    RunTest(clients: 10,   databaseCallTime: 10);
    RunTest(clients: 1000, databaseCallTime: 10);
    RunTest(clients: 10,   databaseCallTime: 1000);
    RunTest(clients: 1000, databaseCallTime: 1000);
}
public static void RunTest(int clients, int databaseCallTime)
{ 
    var aSW = new Stopwatch();
    Console.WriteLine($"Testing {clients} clients with a {databaseCallTime}ms database response time.");
    aSW.Restart();
    {
        Task.WaitAll(
            Enumerable.Range(0, clients)
                .AsParallel()
                .Select(_ => ExecuteAsync(databaseCallTime))
                .ToArray());
        Console.WriteLine($"-> ExecuteAsync returned in {aSW.Elapsed}.");
    }
    aSW.Restart();
    {
        Task.WaitAll(
            Enumerable.Range(0, clients)
                .AsParallel()
                .Select(_ => Task.Run(() => ExecuteSync(databaseCallTime)))
                .ToArray());
        Console.WriteLine($"-> ExecuteSync  returned in {aSW.Elapsed}.");
    }
    Console.WriteLine();
    Console.WriteLine();
}
private static void ExecuteSync(int databaseCallTime)
{
    Thread.Sleep(databaseCallTime);
}
private static async Task ExecuteAsync(int databaseCallTime)
{
    await Task.Delay(databaseCallTime);
}
My results:
Testing 10 clients with a 10ms database response time.
-> ExecuteAsync returned in 00:00:00.1119717.
-> ExecuteSync  returned in 00:00:00.0268717.
Testing 1000 clients with a 10ms database response time.
-> ExecuteAsync returned in 00:00:00.0593431.
-> ExecuteSync  returned in 00:00:01.3065965.
Testing 10 clients with a 1000ms database response time.
-> ExecuteAsync returned in 00:00:01.0126014.
-> ExecuteSync  returned in 00:00:01.0099419.
Testing 1000 clients with a 1000ms database response time.
-> ExecuteAsync returned in 00:00:01.1711554.
-> ExecuteSync  returned in 00:00:25.0433635.
