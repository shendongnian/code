csharp
public async Task ProcessAllPendingWork()
{
    var workerTasks = new List<Task<bool>>();
    foreach(var workerService in _workerServices)
    {
        var workerTask = RunWorker(workerService);
        workerTasks.Add(workerTask);
    }
    await Task.WhenAll(workerTasks);
}
private async Task<bool> RunWorker(Func<bool> workerService)
{
    // use singleton semaphore.
    await _semaphore.WaitAsync();
    try
    {
        return await workerService.DoWorkAsync();
    }
    catch (System.Exception)
    {
        //assume error is a predefined logging service
        Log.Error(ex);
        return false; // ??
    }
    finally
    {
        _semaphore.Release();
    }
}
