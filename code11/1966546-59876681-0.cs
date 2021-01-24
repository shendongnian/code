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
