    public interface IRepository<T>
    {
        ...
        T Load(object id);
    }
