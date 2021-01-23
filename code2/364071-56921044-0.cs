AsyncCollection<int> collection = new AsyncCollection<int>();
var t = Task.Run(async () =>
{
    while (!collection.IsCompleted)
    {
        var item = await collection.TakeAsync();
        
        // process
    }
});
for (int i = 0; i < 1000; i++)
{
    collection.Add(i);
}
collection.CompleteAdding();
t.Wait();
With IAsyncEnumeable:
AsyncCollection<int> collection = new AsyncCollection<int>();
var t = Task.Run(async () =>
{
    await foreach (var item in collection)
    {
        // process
    }
});
for (int i = 0; i < 1000; i++)
{
    collection.Add(i);
}
collection.CompleteAdding();
t.Wait();
