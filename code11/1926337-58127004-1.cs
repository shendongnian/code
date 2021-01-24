    public interface ITestRepository<TContext,T>
        where TContext : DbContext
        where T : BaseEntity
    {       
        List<T> GetAll();
    }
