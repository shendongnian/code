    public interface IUnitOfWork<T>
    {
        IRepository<T> Respository { get; }
    }
    public class UnitOfWork<T> : IUnitOfWork<T>
    {
        public IRepository<T> Respository
        {
            get
            {
                var container = new UnityContainer();
                return container.Resolve<IRepository<T>>();
            }
        }
    }
