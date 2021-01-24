C#
static void Main(string[] args)
{
    TaskParallelLibrary();
    ManualThreads();
    Console.ReadKey();
}
static void ManualThreads()
{
    var queue = new List<string>();
    for (int i = 0; i != 1000000; ++i)
        queue.Add("string" + i);
    var resultList = new List<string>();
    var stopwatch = Stopwatch.StartNew();
    var counter = 0;
    for (int i = 0; i != 10; ++i)
    {
        new Thread(() =>
        {
            while (true)
            {
                var t = "";
                lock (queue)
                {
                    if (counter >= queue.Count)
                        break;
                    t = queue[counter];
                    ++counter;
                }
                t = t.Substring(0, 5);
                string t2 = t.Substring(0, 2) + t;
                lock (resultList)
                    resultList.Add(t2);
            }
        }).Start();
    }
    while (resultList.Count < queue.Count)
        Thread.Sleep(1);
    stopwatch.Stop();
    Console.WriteLine($"Manual threads: Processed {resultList.Count} in {stopwatch.Elapsed}");
}
static void TaskParallelLibrary()
{
    var queue = new List<string>();
    for (int i = 0; i != 1000000; ++i)
        queue.Add("string" + i);
    var stopwatch = Stopwatch.StartNew();
    var resultList = queue.AsParallel().Select(t =>
    {
        t = t.Substring(0, 5);
        return t.Substring(0, 2) + t;
    }).ToList();
    stopwatch.Stop();
    Console.WriteLine($"Parallel: Processed {resultList.Count} in {stopwatch.Elapsed}");
}
On my machine, after running this code several times, I find that the PLINQ code outperforms the Manual Threads by about 30%. Sample output on .NET Core 3.0 preview5-27626-15, built for Release, run standalone:
Parallel: Processed 1000000 in 00:00:00.3629408
Manual threads: Processed 1000000 in 00:00:00.5119985
And, of course, the PLINQ code is:
 - Shorter
 - More maintainable
 - More robust (handles exceptions and return types)
 - Less awkward (no need to poll for completion)
 - More portable (partitions based on number of processors)
 - More flexible (automatically adjusts the thread pool as necessary based on amount of work)
