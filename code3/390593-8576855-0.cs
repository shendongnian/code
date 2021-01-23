    public interface IRepository<T> {
        void AddOrUpdate(T item);
        bool TableExists { get; }
        IEnumerable<T> All { get; }
        ...
        IEnumerable<Detail<T>> GetDetails(string runTime);
        ...
    }
