    // non-generic marker interface (empty)
    public interface IRepository {}
    public interface IRepository<T> : IRepository { … /* as before */ }
    //                              ^^^^^^^^^^^^^
    //                                  added
    public class UnitOfWork
    {
        public TRepository Get<TRepository>() where TRepository : IRepository
                                           // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                                           // this way, no 2nd type parameter is
                                           // needed since the marker interface is
                                           // non-generic.
        { 
            return new UnityContainer().Resolve<TRespository>();
        }
    }
