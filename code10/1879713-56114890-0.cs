    public class GenericRepository<T, TBase> : IDisposable, IGenericRepository<T>, IGenericRepositoryAsync<T>
        where T : TBase, new()
    {
        // Standard methods like: GetById, Update, Delete etc.
    }
