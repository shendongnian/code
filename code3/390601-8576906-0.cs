    public interface IService<T, TDetail, TSummary>
    {
        void AddOrUpdate(T entity);
        void Delete(T entity);
        bool DoesTableExist();
        T Get(T entity);
        T Get(string pk, string rk);
        IEnumerable<T> Get();
        IEnumerable<T> Get(string pk);
        string GetOptions(string pk, string rk);
        IEnumerable<TDetail> ShowDetails(ref string runTime);
        IEnumerable<TSummary> ShowSummary(ref string runTime);
        void ValidateNoDuplicate(T entity);
        void ValidateNoProducts(T entity);
    }
