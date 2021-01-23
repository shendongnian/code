    public interface ISession : IDisposable
    {
        void CommitChanges();
        Db4objects.Db4o.IObjectContainer Container { get; }
        void Delete<T>(System.Linq.Expressions.Expression<Func< T, bool>> expression);
        void Delete(object item);
        void DeleteAll();
        void Dispose();
        T Single<T>(System.Linq.Expressions.Expression<Func< T, bool>> expression);
        System.Linq.IQueryable All();
        void Save<T>(T item);
    }
