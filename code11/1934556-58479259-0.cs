public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) 
{
    if( cache == null || forceRefresh == true)
    {
        await Task.FromResult(TimeSpan.FromSeconds(10));//Simulate a long call;
        cache = new List<Item>{new Item() {Name = "One"}, new Item() {Name = "One"}};
    }
    
    return cache;
}
