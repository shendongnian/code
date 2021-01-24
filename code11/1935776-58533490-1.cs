    public interface ISomeServiceInterace
    {
       somethign CountAsync(ListFilter Filter = null);
    }
   
    ...
    public async Task<IEnumerable<TWhatType>> GetListAsync<TWhatType, TWhatService>()
       where TWhatService : ISomeServiceInterace, new()
