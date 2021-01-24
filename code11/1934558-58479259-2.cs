public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) 
{
    if( cache == null || forceRefresh == true)
    {
        // Simulate a long call (an web api request, for example)
        await Task.Delay(TimeSpan.FromSeconds(10))
        cache = new List<Item>{new Item() {Name = "One"}, new Item() {Name = "One"}};
    }
    
    return cache;
}
----
# Example
## Code 
public interface IDataStore<T>{ Task<IEnumerable<string>> GetItemsAsync(bool forceRefresh = false); }
public class DataStore : IDataStore<string>
{
    List<string> cache;
    public async Task<IEnumerable<string>> GetItemsAsync(bool forceRefresh = false)
    {
        if (cache == null || forceRefresh == true)
        {
            await Task.Delay(TimeSpan.FromSeconds(2)); // Simulate a long call
            cache = new List<string> { "One", "Two" };
        }
        return cache;
    }
    public static async Task Main(string[] args)
    {
        var i = 0;
        var dataStore = new DataStore();
        var sw = Stopwatch.StartNew();
        await dataStore.GetItemsAsync(); //Slow
        Console.WriteLine($"Call {i++} took {sw.ElapsedMilliseconds}ms");
        sw.Restart();
        await dataStore.GetItemsAsync(); //Fast
        Console.WriteLine($"Call {i++} took {sw.ElapsedMilliseconds}ms");
        
        sw.Restart();
        await dataStore.GetItemsAsync(forceRefresh: true); //Fast
        Console.WriteLine($"Call {i++} took {sw.ElapsedMilliseconds}ms");
    }
}
## Output
Call 0 took 2021ms
Call 1 took 0ms
Call 2 took 2004ms
