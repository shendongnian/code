    public interface IRepository<out T> where T : BaseClass
    {
        IEnumerable<T> GetAll();
    }
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseClass, new()
    {
        public abstract IEnumerable<T> GetAll();
    }
    
    public class RepositoryDerived1<T> : RepositoryBase<T> where T : BaseClass, new()
    {
        public override IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
