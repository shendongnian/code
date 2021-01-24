    public interface ISomeService<T>
    {
       Task<int> CountAsync(ListFilter filter = null);
       Task<IEnumerable<T>> ListAsync(ListFilter filter = null);
    }
    ...
    public async Task<IEnumerable<TWhatType>> GetListAsync<TWhatType, TWhatService>(ListFilter filter = null)
       where TWhatService : ISomeService<TWhatType>, new()
    {
        ...
