    private async Task<List<T>> Get<T>(Func<Task<int, int, List<T>>> factory, int skip, int take)
    {
        var totalResults = new List<T>();
        var resultsCount = 1;
        while (resultsCount != 0)
        {
            var results = await factory(skip, take);
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
        return Get<User>((skip, take) => GetUsers(httpClient, arg1, skip, take), 0, 10);
    }
    public Task<List<Item>> GetItemsAsync(HttpClient httpClient, string arg1)
    {
        return Get<Item>((skip, take) => GetItems(httpClient, arg1, skip, take), 10, 10);
    }
