public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) 
{
    if( cache == null || forceRefresh == true)
    {
        await Task.Delay(TimeSpan.FromSeconds(10));//Simulate a long call;
        cache = new List<Item>{new Item() {Name = "One"}, new Item() {Name = "One"}};
    }
    
    return cache;
}
----
# Example
## Code 
public class Item { public string Name { get; set; } }
public interface IDataStore<T>{ Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false); }
public class DataStore : IDataStore<Item>
{
    List<Item> cache;
    public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
    {
        if (cache == null || forceRefresh == true)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));//Simulate a long call;
            cache = new List<Item> { new Item() { Name = "One" }, new Item() { Name = "Two" } };
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
Call 0 took 2027ms
Call 1 took 0ms
Call 2 took 2000ms
