private static StreamWriter logger;
static void Main(string[] args)
{
    // Store your entries from a file in a queue.
    ConcurrentQueue<string> queue = new ConcurrentQueue<string>(System.IO.File.ReadAllLines("input.txt"));
    // Open StreamWriter here.
    logger = File.AppendText("log.txt");
    // Call process method.
    ProcessParallel(queue);
    // Close the StreamWriter after processing is done.
    logger.Close();
}
static void ProcessParallel(ConcurrentQueue<string> collection)
{
    ParallelOptions options = new ParallelOptions()
    {
        // A max of 10 threads can access the file at one time.
        MaxDegreeOfParallelism = 10
    };
    // Start the loop and store the result, so we can check if all the threads are done.
    // The Parallel.For will do all the mutlithreading for you!
    ParallelLoopResult result = Parallel.For(0, collection.Count, options, (i) =>
    {
        string entry;
        if (collection.TryDequeue(out entry))
        {
            Console.WriteLine(entry);
            log(entry);
        }
    });
    // Parallel.ForEach can also be used.
    // Block the main thread while it is still processing the entries...
    while (!result.IsCompleted) ;
    // Every thread is done
    Console.WriteLine("Multithreaded loop is done!");
}
private static void log(string data)
{
    if (logger.BaseStream == null)
    {
        // Cannot log, because logger.Close(); was called.
        return;
    }
    logger.WriteLine(data);
}
