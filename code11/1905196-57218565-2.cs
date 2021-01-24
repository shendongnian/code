    private async Task<List<T>> Get<T>(Func<Task<List<T>>> factory)
    {
        ...
    }
    public Task<List<User>> GetUsersAsync(HttpClient httpClient, string arg1)
    {
        return Get<User>(() => GetUsers(httpClient, arg1, 0, 10));
    }
    public Task<List<Item>> GetItemsAsync(HttpClient httpClient, string arg1)
    {
        return Get<Item>(() => GetItems(httpClient, arg1, , 10, 10));
    }
