    private async Task<List<T>> Get<T>(Func<Task<List<T>>> factory)
    {
        var totalResults = new List<T>();
        int skip = 0, resultsCount = 1;
        while (resultsCount != 0)
        {
            var results = await factory();
            if (results != null)
            {
                totalResults.AddRange(results);
                resultsCount = results.Count;
                skip += resultsCount;
            }
            else
            {
                resultsCount = 0;
            }
        }
        return totalResults;
    }
    public Task<List<User>> GetUsersAsync(HttpClient httpClient, string arg1)
    {
        return Get<User>(() => GetUsers(httpClient, arg1));
    }
    public Task<List<Item>> GetItemsAsync(HttpClient httpClient, string arg1)
    {
        return Get<Item>(() => GetItems(httpClient, arg1));
    }
