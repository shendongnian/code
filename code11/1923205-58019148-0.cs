    public async Task<T> GetItemAsync<T> (...)
    {
       var item = await client.ReadDocumentAsync<T>(...);
       return item;
    }
