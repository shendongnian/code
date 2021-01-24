csharp
async Task Async(Func<Task> asyncDelegate) =>
    await asyncDelegate().ConfigureAwait(false);
This technique can be easly wrapped inside a "`Collector`" type:
csharp
class AsyncCollector
{
    public IReadOnlyList<Task> Tasks => _tasks.AsReadOnly();
    private readonly List<Task> _tasks = new List<Task>();
    public void Register(Func<Task> asyncDelegate) =>
        this.Register(asyncDelegate, out _);
    public void Register(Func<Task> asyncDelegate, out Task registeredTask)
    {
        registeredTask = Async(asyncDelegate);
        _tasks.Add(registeredTask);
    }
    public async Task WhenAll(bool clearAfterwards = true)
    {
        try { await Task.WhenAll(_tasks); }
        finally { if (clearAfterwards) _tasks.Clear(); }
    }
    public void Clear() => _tasks.Clear();
    private async Task Async(Func<Task> asyncDelegate) =>
        await asyncDelegate().ConfigureAwait(false);
}
Which then gets used like this:
csharp
var collector = new AsyncCollector();
collector.Register(async () => model.Books = await _client.GetBooks(clientId));
collector.Register(async () => model.Extras = await _client.GetBooksExtras(clientId));
collector.Register(async () => model.Invoices = await _client.GetBooksInvoice(clientId));
collector.Register(async () => model.Receipts = await _client.GetBooksReceipts(clientId));
await collector.WhenAll();
  [1]: https://stackoverflow.com/questions/57108395/how-to-bundle-async-tasks-for-task-whenall#57108505
  [2]: https://stackoverflow.com/questions/43089372/when-does-a-c-sharp-task-actually-start
