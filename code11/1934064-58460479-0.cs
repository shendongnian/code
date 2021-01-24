private static readonly Object lockObject = new Object(); // just a random object used to decide whether the thread has locked the Singleton functions
private static int queueCount = 0; // tracked across multiple threads
bool lockWasTaken = false;
try
{
    // Increments the queueCount variable across multiple threads
    // https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.increment?view=netframework-4.8
    Interlocked.Increment(ref queueCount);
    Monitor.TryEnter(lockObject, ref lockWasTaken); // returns lockWasTaken = true if it can get a lock
    if (!lockWasTaken)
    {
        log.Warn("Locked by existing request. Request is queued. Queue length is " + (queueCount - 1).ToString()); // subtract since the first request is already processing
        Monitor.Enter(lockObject, ref lockWasTaken); // Goes into the queue to access the object
    }
    // Do the Singleton processing
}
catch(Exception ex)
{
    log.Fatal(ex);
}
finally
{
    if (lockWasTaken)
    {
        Monitor.Exit(lockObject);
    }
    // Reduce the queue count
    Interlocked.Decrement(ref queueCount);
}
