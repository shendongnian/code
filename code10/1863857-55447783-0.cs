    public class MyRepository
    {
        public async Task<List<Cars>> GetAllCarsAsync()
        {
            return await _RepositoryContext.Set<Cars>().ToListAsync();
        }
    }
