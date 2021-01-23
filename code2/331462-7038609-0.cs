    public interface IRepository { }
    public interface IRepository<T> : IRepository { }
    public class UnitOfWork
    {
        public TRepository Get<TRepository>() where TRepository : IRepository
        {
            return new UnityContainer().Resolve<TRespository>();
        }
    }
