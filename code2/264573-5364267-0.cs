    public interface IObservableRepository<T, TContext>
    {
        IObservable<T> GetById(int id);
        IObservable<IList<T>> GetAll(Func<TContext, IQueryable<T>> funcquery);
        IObservable<int[]> SubmitInserts(IList<T> inserts);
        IObservable<int[]> SubmitDeletes(IList<T> deletes);
        IObservable<int[]> SubmitUpdates(IList<T> updates);
        //helpers
        IObservable<int> SubmitInsert(T entity);
        IObservable<int> SubmitDelete(T entity);
        IObservable<int> SubmitUpdate(T entity);
    }
