csharp
// Instance received from an external API.
var transport = new Transport
{
    Vehichle = new Vehichle { Id = "1234" },
    Stops = new List<Stop>
    {
        new Stop { Id = "a1" },
        new Stop { Id = "b2" },
        new Stop { Id = "c3" },
    }
};
// Integrate the received data with our "translations".
await IntegrateDataAsync(transport);
In order to reduce the verbosity of the operation I usually use a helper method called `Async`, that wraps an async delegate, and that can be awaited.
csharp
async Task Async(Func<Task> asyncDelegate) =>
    await asyncDelegate().ConfigureAwait(false);
E.g:
csharp
var tasks = new List<Task>();
// The data fetch and assignment is wrapped inside a delegate
// which gets passed to the helper Async function.
var vehichleNameTask = Async(async () =>
    transport.Vehichle.Name = await GetVehichleNameAsync(transport.Vehichle.Id));
// The task represent the completion of the assignment,
// without the need to handle any returning value.
tasks.Add(vehichleNameTask);
if (transport.Stops != null)
{
    foreach (var s in transport.Stops)
        // The invocation is usually shorten like this:
        tasks.Add(Async(async () => s.Description = await GetStopDescription(s.Id)));
}
await Task.WhenAll(tasks);
// Local functions
Task<string> GetVehichleNameAsync(string vehicleId) => Task.FromResult("A vehichle");
Task<string> GetStopDescription(string stopId) => Task.FromResult("A stop");
// This function wraps a task-returning delegate, enabling to await the operation.
async Task Async(Func<Task> asyncDelegate) =>
    await asyncDelegate().ConfigureAwait(false);
This mechanism can be easily wrapped inside a `Collector` type, that would also hide the use of the list of tasks.
---
These are the types used for this example:
csharp
class Transport
{
    public Vehichle Vehichle { get; set; }
    public List<Stop> Stops { get; set; }
}
class Vehichle
{
    public string Id { get; set; }
    public string Name { get; set; }
}
class Stop
{
    public string Id { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
}
  [1]: https://stackoverflow.com/questions/57108395/how-to-bundle-async-tasks-for-task-whenall#57108505
  [2]: https://stackoverflow.com/questions/43089372/when-does-a-c-sharp-task-actually-start
