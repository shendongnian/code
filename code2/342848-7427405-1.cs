    public interface INamedFactory
    {
        object GetByKey(string key);
    }
    public interface INamedFactory<T> : INamedFactory
    {
        T GetByKey(string key);
    }
