public async Task<List<Informations>> DoSthAsync()
{
    // Kick off both tasks
    var firstTask = FirstTask();
    var secondTask = SecondTask();
    await Task.WhenAll(firstTask, secondTask);
    var informations = firstTask.Result;
    informations.AddRange(secondTask.Result);
    return informations;
}
public Task<List<Informations>> FirstTask()
{
    return Task.Run(() => ...);
}
public Task<List<Informations>> SecondTask()
{
    return Task.Run(() => ...);
}
Alternatively, you can use one of the [concurrent collections](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent?view=netframework-4.8) to collect your results. If the order of the results is not important, use a `ConcurrentBag<T>:
public async Task<IReadOnlyCollection<Informations>> DoSthAsync
{
    var informations = new ConcurrentBag<Informations>();
    await Task.WhenAll(FirstTask(informations), SecondTask(informations));
    return informations;
}
public async Task FirstTask(ConcurrentBag<Informations> list)
{
    await Task.Run( () => //do sth with list);
}
public async Task SecondTask(ConcurrentBag<Informations> list)
{ 
    await Task.Run( () => //do sth with list);
}
